using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessagesManager : IMessagesService
    {
        IMessagesDal _messagesDal;

        public MessagesManager(IMessagesDal messagesDal)
        {
            _messagesDal = messagesDal;
        }

        public Messages GetById(int id)
        {
            return _messagesDal.GetById(id);
        }

        public List<Messages> GetList()
        {
            return _messagesDal.GetListAll();
        }

        public List<Messages> GetListByWriter(int RevicerId)
        {
            return _messagesDal.GetListWithMessageByWriter(RevicerId);
        }

 

        public void TAdd(Messages t)
        {
            _messagesDal.Insert(t);
        }

        public void TDelete(Messages t)
        {
            _messagesDal.Delete(t);
        }

        public void TUpdate(Messages t)
        {
            _messagesDal.Update(t);
        }
    }
}
