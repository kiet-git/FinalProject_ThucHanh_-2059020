using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleSoanDe
{ 
    public class FormCauHoiCreator
    {
        private NormalQCollection _iqc;
        private bool _isLocked = false;

        public bool IsLocked
        {
            set
            {
                _isLocked = value;
            }
        }

        public FormCauHoiCreator(NormalQCollection qc, bool locked)
        {
            _iqc = qc;
            _isLocked = locked;
        }

        public void showFormCauHoi(Question q)
        {
            FormCauHoi fsch = new FormCauHoi(q);
            fsch.FormCauHoi_ExitWithoutSave += new FormCauHoi.FormCauHoi_ExitHandle(_iqc.removeEnd);
            fsch.FormCauHoi_ExitNormal += new FormCauHoi.FormCauHoi_ExitHandle(_iqc.resetBinding);
            if (_isLocked)
            {
                fsch.lockForm();
            }
            fsch.ShowDialog();
        }
    }
}
