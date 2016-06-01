using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWeb.IDAL;

namespace MyWeb.DAL
{
    public class MessageBoardDAL:BaseDAO<Model.MessageBoard>,IMessageBoardDAL
    {
    }
}
