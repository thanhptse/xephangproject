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
    [RoutePrefix("api/room")]
//    [Authorize]
    public class RoomController : ApiControllerBase
    {
        IRoomService _roomService;

        public RoomController(IErrorService errorService, IRoomService roomService) :
            base(errorService)
        {
            this._roomService = roomService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var listRoom = _roomService.GetAll();

                totalRow = listRoom.Count();
                var query = listRoom.OrderBy(x => x.RoomId).Skip(page * pageSize).Take(pageSize);

                var listRoomVm = Mapper.Map<IEnumerable<Room>, IEnumerable<RoomViewModel>>(query);

                var paginationSet = new PaginationSet<RoomViewModel>()
                {
                    Items = listRoomVm,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, paginationSet);

                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, RoomViewModel roomVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newRoom = new Room();
                    newRoom.UpdateRoom(roomVM);
                    newRoom.CreatedDate = DateTime.Now;
                    _roomService.Add(newRoom);
                    _roomService.SaveChanges();

                    var responseData = Mapper.Map<Room, RoomViewModel>(newRoom);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, RoomViewModel roomVM)
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

                    var dbRoom = _roomService.GetById(roomVM.RoomId);
                    dbRoom.UpdateRoom(roomVM);
                    dbRoom.ModifiledDate = DateTime.Now;
                    dbRoom.ModifiledBy = User.Identity.Name;
                    _roomService.Update(dbRoom);
                    _roomService.SaveChanges();

                    var responseData = Mapper.Map<Room, RoomViewModel>(dbRoom);
                    respone = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return respone;
            });
        }

        [Route("getbyid/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _roomService.GetById(id);


                var reponseData = Mapper.Map<Room, RoomViewModel>(model);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, reponseData);

                return response;
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
                    var oldRoom = _roomService.Delete(id);
                    _roomService.SaveChanges();

                    var reponseData = Mapper.Map<Room, RoomViewModel>(oldRoom);

                    respone = request.CreateResponse(HttpStatusCode.OK, reponseData);
                }

                return respone;
            });
        }

        [Route("getallroom")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _roomService.GetAll();

                var responseData = Mapper.Map<IEnumerable<Room>, IEnumerable<RoomViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
    }
}
