using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace _CS511__SocialNetworkApplication.View
{
    public partial class VidPlayer : UserControl
    {
        public VidPlayer(string url)
        {
            InitializeComponent();
            VideoPlayer.URL = Path.GetFullPath(url);
            VideoPlayer.Ctlcontrols.stop();
        }
    }
}
