using System;
using System.Collections.Generic;
using System.Linq;
using XepHang.Data.Infrastructure;
using XepHang.Data.Repositories;
using XepHang.Model.Models;

namespace XepHang.Service
{
    public interface IOrderService
    {
        void Add(Order order);

        void Update(Order order);

        Order Delete(int id);

        IEnumerable<Order> GetAll();

        IEnumerable<Order> GetAllPaging(int page, int pageSize, out int totalRow);

        IEnumerable<Order> GetAllByRoomPaging(int room, int page, int pageSize, out int totalRow);

        Order GetById(int id);

        IEnumerable<Order> GetAllByDate(string date, int page, int pageSize, out int totalRow);

        void SaveChanges();
    }
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;
        INumberReportRepository _numberreportRepository;

        IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository orderRepository, INumberReportRepository numberreportRepository, IUnitOfWork unitOfWork)
        {
            this._orderRepository = orderRepository;
            this._numberreportRepository = numberreportRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Order order)
        {
            IQueryable<NumberReport> numReports = _numberreportRepository.GetByRoomAndDate(order.RoomId);
            
            NumberReport num = numReports.First();
            order.ChosenNumber = num.TotalNumberOrder + 1;
            _orderRepository.Add(order);

            num.TotalNumberOrder = num.TotalNumberOrder + 1;
            _numberreportRepository.Update(num);

        }

        public Order Delete(int id)
        {
            return _orderRepository.Delete(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public IEnumerable<Order> GetAllByDate(string date, int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAllByRoomPaging(int room, int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public Order GetById(int id)
        {
            return _orderRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Order order)
        {
            _orderRepository.Update(order);
        }
    }
}
