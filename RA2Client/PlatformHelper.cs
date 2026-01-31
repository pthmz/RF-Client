using System;
using System.Runtime.InteropServices;

namespace ClientCore
{
    public static class PlatformHelper
    {
        public static bool IsWine()
        {
            // Wine 下常见环境变量之一
            if (Environment.GetEnvironmentVariable("WINELOADERNOEXEC") != null)
                return true;

            // 兜底：Wine 会把自己伪装成 Windows
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // Wine 下常见特征：System32 路径存在但版本异常
                var winePrefix = Environment.GetEnvironmentVariable("WINEPREFIX");
                if (!string.IsNullOrEmpty(winePrefix))
                    return true;
            }

            return false;
        }
    }
}
