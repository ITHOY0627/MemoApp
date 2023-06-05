using System;
using System.Collections.Generic;
using System.Text;

namespace MemoApp.Interfaces
{
    public interface IShareFilePermission
    {
        void GrantPermission(string path, string mimeType);
    }
}
