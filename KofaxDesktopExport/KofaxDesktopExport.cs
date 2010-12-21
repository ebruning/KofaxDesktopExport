using System;
using System.Collections.Generic;
using System.Text;
using Kofax.Eclipse.Base;
using System.Windows.Forms;

namespace KofaxDesktopExport
{
    public class KofaxDesktopExport :IReleaseScript2
    {
        private ReleaseMode _workingMode;

        public void CustomizeSettings(IList<IExporter> exporters, IJob job, IApplication licenseData)
        {
            
        }

        public string Description
        {
            get { return "Simulate the file saving in Kofax Dekstop"; }
        }

        public void DeserializeSettings(System.IO.Stream input)
        {
            
        }

        public void EndBatch(IBatch batch, object handle, ReleaseResult result)
        {
            throw new NotImplementedException();
        }

        public void EndDocument(IDocument doc, object handle, ReleaseResult result)
        {
            throw new NotImplementedException();
        }

        public void EndRelease(object handle, ReleaseResult result)
        {
            throw new NotImplementedException();
        }

        public Guid Id
        {
            get { return new Guid("{FADF3B93-C071-4009-9229-8CB1D5BE0B59}"); }
        }

        public bool IsSupported(ReleaseMode mode)
        {
            return true;
        }

        public string Name
        {
            get { return "Custom File Naming"; }
        }

        public void Release(IPage page)
        {
            
        }

        public void Release(IDocument doc)
        {
            
        }

        public void SerializeSettings(System.IO.Stream output)
        {
           
        }

        public void Setup(IList<IExporter> exporters, IJob job, IDictionary<string, string> releaseData, IApplication licenseData)
        {
            
        }

        public object StartBatch(IBatch batch)
        {
            return null;
        }

        public object StartDocument(IDocument doc)
        {
            return null;
        }

        public object StartRelease(IList<IExporter> exporters, IIndexField[] indexFields, IDictionary<string, string> releaseData, IApplication licenseData)
        {
            return null;
        }

        public ReleaseMode WorkingMode
        {
            get { return _workingMode; }
        }

        #region Not Used
        public void Setup(IList<IExporter> exporters, IIndexField[] indexFields, IDictionary<string, string> releaseData)
        {
            //Not used
        }

        public object StartRelease(IList<IExporter> exporters, IIndexField[] indexFields, IDictionary<string, string> releaseData)
        {
            //Not used
        } 
        #endregion
    }
}
