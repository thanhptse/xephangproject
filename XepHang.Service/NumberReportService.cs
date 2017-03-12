using System;
using System.Collections.Generic;
using XepHang.Data.Infrastructure;
using XepHang.Data.Repositories;
using XepHang.Model.Models;

namespace XepHang.Service
{
    
    public interface INumberReportService
    {
        void Add(NumberReport report);

        void Update(NumberReport report);

        NumberReport Delete(int id);

        IEnumerable<NumberReport> GetAll();

        IEnumerable<NumberReport> GetAllPaging(int page, int pageSize, out int totalRow);

        IEnumerable<NumberReport> GetAllByRoomPaging(int room, int page, int pageSize, out int totalRow);

        NumberReport GetById(int id);

        IEnumerable<NumberReport> GetAllByDate(string date, int page, int pageSize, out int totalRow);

        void SaveChanges();
    }
    public class NumberReportService : INumberReportService
    {
        INumberReportRepository _numberreportRepository;
        IUnitOfWork _unitOfWork;

        public NumberReportService(INumberReportRepository numberreportRepository, IUnitOfWork unitOfWork)
        {
            this._numberreportRepository = numberreportRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(NumberReport report)
        {
            _numberreportRepository.Add(report);
        }

        public NumberReport Delete(int id)
        {
            return _numberreportRepository.Delete(id);
        }

        public IEnumerable<NumberReport> GetAll()
        {
            return _numberreportRepository.GetAll();
        }

        public IEnumerable<NumberReport> GetAllByDate(string date, int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NumberReport> GetAllByRoomPaging(int room, int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NumberReport> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public NumberReport GetById(int id)
        {
            return _numberreportRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(NumberReport report)
        {
            _numberreportRepository.Update(report);
        }
    }
}
