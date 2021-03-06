using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
   public class EfMessagesRepository : GenericRepository<Messages>, IMessagesDal
    {
        
        public List<Messages> GetListWithMessageByWriter(int id)
        {
            using (var context = new Context())
            {
                return context.Messagess.Include(x => x.SenderUser).Where(x => x.ReciverID == id).ToList();
            }
        }

        
    }
}
