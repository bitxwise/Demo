using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatiN.Core;
using System.Threading;

namespace DemoApplication.Specs
{
    public class IEStaticInstanceHelper
    {
        private IE _IE;
        private int _ieThread;
        private string _ieHwnd;

        public IE IE
        {
            get
            {
                var currentThreadId = GetCurrentThreadId();
                if (currentThreadId != _ieThread)
                {
                    _IE = IE.AttachTo<IE>(Find.By("hwnd", _ieHwnd));
                    _ieThread = currentThreadId;
                }
                return _IE;
            }
            set
            {
                _IE = value;
                _ieHwnd = _IE.hWnd.ToString();
                _ieThread = GetCurrentThreadId();
            }
        }

        private int GetCurrentThreadId()
        {
            return Thread.CurrentThread.GetHashCode();
        }
    }
}
