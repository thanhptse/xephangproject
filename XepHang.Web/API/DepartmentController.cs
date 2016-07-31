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
    //[Authorize]
    public class DepartmentController : ApiControllerBase
    {
        IDepartmentService _departmentService;

        public DepartmentController(IErrorService errorService, IDepartmentService departmentService) :
            base(errorService)
        {
            this._departmentService = departmentService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var listDepartment = _departmentService.GetAll();

                totalRow = listDepartment.Count();
                var query = listDepartment.OrderBy(x=>x.DepartmentId).Skip(page * pageSize).Take(pageSize);

                var listDepartmentVm = Mapper.Map<IEnumerable<Department>,IEnumerable<DepartmentViewModel>>(query);

                var paginationSet = new PaginationSet<DepartmentViewModel>()
                {
                    Items = listDepartmentVm,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, paginationSet);

                return response;
            });
        }


        [Route("create")]
        public HttpResponseMessage Post(HttpRequestMessage request, DepartmentViewModel departmentVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage respone = null;
                if (!ModelState.IsValid)
                {
                    respone = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }else
                {
                    
                    var newDepartment = new Department();
                    newDepartment.UpdateDepartment(departmentVM);
                    newDepartment.CreatedDate = DateTime.Now;
                    newDepartment.CreateBy = User.Identity.Name;
                    _departmentService.Add(newDepartment);
                    _departmentService.SaveChanges();

                    var responseData = Mapper.Map<Department, DepartmentViewModel>(newDepartment);
                    respone = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                
                return respone;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, DepartmentViewModel departmentVM)
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

                    var dbDepartment = _departmentService.GetById(departmentVM.DepartmentId);
                    dbDepartment.UpdateDepartment(departmentVM);
                    dbDepartment.ModifiledDate = DateTime.Now;
                    dbDepartment.ModifiledBy = User.Identity.Name;
                    _departmentService.Update(dbDepartment);
                    _departmentService.SaveChanges();

                    var responseData = Mapper.Map<Department, DepartmentViewModel>(dbDepartment);
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
                var model = _departmentService.GetById(id);


                var reponseData = Mapper.Map<Department, DepartmentViewModel>(model);

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
                   var oldDepartment =  _departmentService.Delete(id);
                    _departmentService.SaveChanges();

                    var reponseData = Mapper.Map<Department, DepartmentViewModel>(oldDepartment);

                    respone = request.CreateResponse(HttpStatusCode.OK, reponseData);
                }

                return respone;
            });
        }

        [Route("getalldepartment")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _departmentService.GetAll();

                var responseData = Mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
    }
}