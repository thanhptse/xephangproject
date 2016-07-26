using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XepHang.Data.Infrastructure;
using XepHang.Data.Repositories;
using XepHang.Model.Models;

namespace XepHang.Service
{
    public interface IDepartmentService
    {
        Department Add(Department department);

        void Update(Department department);

        void Delete(int id);

        IEnumerable<Department> GetAll();

        IEnumerable<Department> GetAllPaging(int page, int pageSize, out int totalRow);

        IEnumerable<Department> GetAllByRoomPaging(int room, int page, int pageSize, out int totalRow);

        Order GetById(int id);


        void SaveChanges();
    }
    public class DepartmentService : IDepartmentService
    {
        IDepartmentRepository _departmentRepository;
        IUnitOfWork _unitOfWork;

        public DepartmentService(IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork)
        {
            this._departmentRepository = departmentRepository;
            this._unitOfWork = unitOfWork;
        }

        public Department Add(Department department)
        {
            return _departmentRepository.Add(department);
        }

        public void Delete(int id)
        {
            _departmentRepository.Delete(id);
        }

        public IEnumerable<Department> GetAll()
        {
            return _departmentRepository.GetAll();
        }

        public IEnumerable<Department> GetAllByRoomPaging(int room, int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Department department)
        {
            _departmentRepository.Update(department);
        }
    }
}
