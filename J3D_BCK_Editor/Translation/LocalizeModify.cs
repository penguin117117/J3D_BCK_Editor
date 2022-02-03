using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace J3D_BCK_Editor.Translation
{
    public class LocalizeModify
    {
        private readonly ITranslation _translation;
        private readonly Form.ControlCollection _formControls;
        
        public LocalizeModify(ITranslation translation, Form.ControlCollection formControls) 
        {
            _translation = translation;
            _formControls = formControls;
        }

        
    }
}
