using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XepHang.Model.Models;
using XepHang.Service;
using XepHang.Web.Infrastructure.Core;
using XepHang.Web.Infrastructure.Extensions;
using XepHang.Web.Models;

namespace XepHang.Web.API
{
    [RoutePrefix("api/order")]
    //[Authorize]
    public class OrderController : ApiControllerBase
    {
        IOrderService _orderService;

        public OrderController(IErrorService errorService, IOrderService orderService) :
            base(errorService)
        {
            this._orderService = orderService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var listOrder = _orderService.GetAll();

                totalRow = listOrder.Count();
                var query = listOrder.OrderBy(x => x.RoomId).Skip(page * pageSize).Take(pageSize);

                var listOrderVm = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(query);

                var paginationSet = new PaginationSet<OrderViewModel>()
                {
                    Items = listOrderVm,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, paginationSet);

                return response;
            });
        }

        [Route("create")]
        public HttpResponseMessage Post(HttpRequestMessage request, OrderViewModel orderVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage respone = null;
                if (!ModelState.IsValid)
                {
                    respone = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {

                    var newOrder = new Order();
                    newOrder.UpdateOrder(orderVM);
                    if (newOrder.Username == null || newOrder.Username == "")
                    {
                        newOrder.Username = User.Identity.Name;
                    }
                    newOrder.CreateDate = DateTime.Now;

                    _orderService.Add(newOrder);
                    _orderService.SaveChanges();

                    var responseData = Mapper.Map<Order, OrderViewModel>(newOrder);
                    respone = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return respone;
            });
        }

        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage respone = null;
                if (!ModelState.IsValid)
                {
                    respone = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldOrder = _orderService.Delete(id);
                    _orderService.SaveChanges();

                    var reponseData = Mapper.Map<Order, OrderViewModel>(oldOrder);

                    respone = request.CreateResponse(HttpStatusCode.OK, reponseData);
                }

                return respone;
            });
        }

        [Route("getbyid/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _orderService.GetById(id);


                var reponseData = Mapper.Map<Order, OrderViewModel>(model);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, reponseData);

                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, OrderViewModel orderVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage respone = null;
                if (!ModelState.IsValid)
                {
                    respone = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {

                    var dbOrder = _orderService.GetById(orderVM.OrderId);
                    dbOrder.UpdateOrder(orderVM);
                    dbOrder.ModifiledDate = DateTime.Now;
                    dbOrder.ModifiledBy = User.Identity.Name;
                    _orderService.Update(dbOrder);
                    _orderService.SaveChanges();

                    var responseData = Mapper.Map<Order, OrderViewModel>(dbOrder);
                    respone = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return respone;
            });
        }
    }
}
