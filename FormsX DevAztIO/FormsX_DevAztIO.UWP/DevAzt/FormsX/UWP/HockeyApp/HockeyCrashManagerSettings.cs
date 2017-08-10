using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// using HockeyApp.Android;

namespace DevAzt.FormsX.Droid.HockeyApp
{
    /*
    public class HockeyCrashManagerSettings : CrashManagerListener
    {
        Application _application;

        public HockeyCrashManagerSettings(Application app)
        {
            _application = app;
        }

        public override string UserID
        {
            get
            {
                string iduser = "0";
                if(Forms.App.Oauth != null)
                {
                    iduser = Forms.App.Oauth.IdUsuario.ToString();
                }
                return iduser;
            }
        }

        public override string Description
        {
            get
            {
                string description = "";
                try
                {
                    var appjson = Forms.App.ToJson();
                    description = "{ App: " + appjson + " }";
                }
                catch
                {

                }
                return description;
            }
        }

        public override bool ShouldAutoUploadCrashes()
        {
            return true;
        }
    }
    */
}