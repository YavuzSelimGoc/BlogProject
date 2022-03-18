using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
  public  interface IMessagesService : IGenericService<Messages>
    {
        List<Messages> GetListByWriter(int RevicerMail);
    }
}
