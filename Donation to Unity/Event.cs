using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donation
{
    //이벤트핸들러 선언(자료형은 자유)
    public delegate void MyEventHandlerint(int A);
    public delegate void MyEventHandlerbool(bool a);

    //클래스별로 이벤트 추가
    public partial class Twip
    {
        public event MyEventHandlerint twipmoneycomeevent;
        public event MyEventHandlerbool twipconnectedevent;
    }
    public partial class Toonation
    {
        public event MyEventHandlerint toonationmoneycomeevent;
        public event MyEventHandlerbool toonationconnectedevent;
    } 
}
namespace Donation_attack_into_VRC
{
    //이벤트 핸들러 설정
    public delegate void MyEventHandler();

    //클래스에 이벤트 추가
    public partial class addparameterform
    {
        public event MyEventHandler Sendlist;
    }
}
