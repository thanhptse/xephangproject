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
    [RoutePrefix("api/numberreport")]
    [Authorize]
    public class NumberReportController : ApiControllerBase
    {
        INumberReportService _numberreportService;

        public NumberReportController(IErrorService errorService, INumberReportService numberreportService) :
            base(errorService)
        {
            this._numberreportService = numberreportService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var listOrder = _numberreportService.GetAll();

                totalRow = listOrder.Count();
                var query = listOrder.OrderBy(x => x.RoomId).Skip(page * pageSize).Take(pageSize);

                var listNumberReportVm = Mapper.Map<IEnumerable<NumberReport>, IEnumerable<NumberReportViewModel>>(query);

                var paginationSet = new PaginationSet<NumberReportViewModel>()
                {
                    Items = listNumberReportVm,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, paginationSet);

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
                    var oldNumberreport = _numberreportService.Delete(id);
                    _numberreportService.SaveChanges();

                    var reponseData = Mapper.Map<NumberReport, NumberReportViewModel>(oldNumberreport);

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
                var model = _numberreportService.GetById(id);


                var reponseData = Mapper.Map<NumberReport, NumberReportViewModel>(model);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, reponseData);

                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, NumberReportViewModel numberreportVM)
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

                    var dbNumberreport = _numberreportService.GetById(numberreportVM.Id);
                    dbNumberreport.UpdateNumberreport(numberreportVM);
                    _numberreportService.Update(dbNumberreport);
                    _numberreportService.SaveChanges();

                    var responseData = Mapper.Map<NumberReport, NumberReportViewModel>(dbNumberreport);
                    respone = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return respone;
            });
        }
    }
}
