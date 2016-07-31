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
    public interface IRoomService
    {
        Room Add(Room room);

        void Update(Room room);

        Room Delete(int id);

        IEnumerable<Room> GetAll();

        IEnumerable<Room> GetAllPaging(int page, int pageSize, out int totalRow);

        IEnumerable<Room> GetAllByRoomPaging(int room, int page, int pageSize, out int totalRow);

        Room GetById(int id);


        void SaveChanges();
    }

    public class RoomService : IRoomService
    {
        IRoomRepository _roomRepository;
        IUnitOfWork _unitOfWork;

        public RoomService(IRoomRepository roomRepository, IUnitOfWork unitOfWork)
        {
            this._roomRepository = roomRepository;
            this._unitOfWork = unitOfWork;
        }

        public Room Add(Room room)
        {
            return _roomRepository.Add(room);
        }

        public Room Delete(int id)
        {
            return _roomRepository.Delete(id);
        }

        public IEnumerable<Room> GetAll()
        {
            return _roomRepository.GetAll();
        }

        public IEnumerable<Room> GetAllByRoomPaging(int room, int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public Room GetById(int id)
        {
            return _roomRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Room room)
        {
            _roomRepository.Update(room);
        }
    }
}
