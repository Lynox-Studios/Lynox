using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynox.LynoxAPI.SystemFetcher
{
    public static class FetchService
    {
        public static string ReturnFromLibrary(string fetchpath)
        {
            switch (fetchpath)
            {
                case "fetch/config_file":
                    return SYSTEM_CONFIG_FILE;
                case "fetch/user/name":
                    return SYSTEM_USER_PATH_NAME;
                case "fetch/user/passwd":
                    return SYSTEM_USER_PATH_PASS;
                case "fetch/system/mode":
                    return SYSTEM_MODE_CONFIG;
                case "fetch/system/bin_enable":
                    return SYSTEM_CONFIG_BIN_ENABLED;
                default:
                    return "ERROR";
            }
        }

        public static string GiveAbsolutePath(string item)
        {
            switch (item)
            {
                case SYSTEM_CONFIG_FILE_:
                    return "0:\\sys_config.conf";
                case SYSTEM_USER_PATH_NAME_:
                    return "0:\\system\\user.conf";
                case SYSTEM_USER_PATH_PASS_:
                    return "0:\\system\\passwd.conf";
                case SYSTEM_MODE_CONFIG_:
                    return "0:\\system\\system_mode.conf";
                case SYSTEM_CONFIG_BIN_ENABLED_:
                    return "0:\\system\\bin_enabled.conf";
                default:
                    return "ERROR";
            }
        }

        public static string[] SYSTEM_CONFIG_BUNDLE = { SYSTEM_CONFIG_FILE, SYSTEM_USER_PATH_NAME, SYSTEM_USER_PATH_PASS,
                                                        SYSTEM_MODE_CONFIG, SYSTEM_CONFIG_BIN_ENABLED };

        public static string SYSTEM_CONFIG_FILE = "SYSTEM_CONFIG_FILE";
        public static string SYSTEM_USER_PATH_NAME = "SYSTEM_USER_PATH_NAME";
        public static string SYSTEM_USER_PATH_PASS = "SYSTEM_USER_PATH_PASS";
        public static string SYSTEM_MODE_CONFIG = "SYSTEM_MODE_CONFIG";
        public static string SYSTEM_CONFIG_BIN_ENABLED = "SYSTEM_CONFIG_BIN_ENABLED";

        public const string SYSTEM_CONFIG_FILE_ = "SYSTEM_CONFIG_FILE";
        public const string SYSTEM_USER_PATH_NAME_ = "SYSTEM_USER_PATH_NAME";
        public const string SYSTEM_USER_PATH_PASS_ = "SYSTEM_USER_PATH_PASS";
        public const string SYSTEM_MODE_CONFIG_ = "SYSTEM_MODE_CONFIG";
        public const string SYSTEM_CONFIG_BIN_ENABLED_ = "SYSTEM_CONFIG_BIN_ENABLED";
    }
}
