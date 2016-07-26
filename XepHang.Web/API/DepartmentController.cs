using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XepHang.Model.Models;
using XepHang.Service;
using XepHang.Web.Infrastructure.Core;
using XepHang.Web.Models;
using XepHang.Web.Infrastructure.Extensions;
using AutoMapper;

namespace XepHang.Web.API
{
    [RoutePrefix("api/department")]
    [Authorize]
    public class DepartmentController : ApiControllerBase
    {
        IDepartmentService _departmentService;

        public DepartmentController(IErrorService errorService, IDepartmentService departmentService) :
            base(errorService)
        {
            this._departmentService = departmentService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listDepartment = _departmentService.GetAll();

                var listDepartmentVm = Mapper.Map<List<DepartmentViewModel>>(listDepartment);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listDepartmentVm);
                //HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listDepartment);

                return response;
            });
        }

        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, DepartmentViewModel departmentVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    Department newDepartment = new Department();
                    newDepartment.UpdateDepartment(departmentVm);

                    var department = _departmentService.Add(newDepartment);
                    _departmentService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.Created, department);

                }
                return response;
            });
        }

        
    }
}