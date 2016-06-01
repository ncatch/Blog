using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWeb.Model;
using MyWeb.IDAL;
using MyWeb.IBLL;

namespace MyWeb.BLL
{
    public class MessageBoardManager:BaseManager<Model.MessageBoard,IMessageBoardDAL>,IMessageBoardManager
    {

    }
}
