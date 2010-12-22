using System;
using System.Collections.Generic;
using System.Text;
using Kofax.Eclipse.Base;
using System.Windows.Forms;
using System.IO;

namespace KofaxDesktopExport
{
    public class KofaxDesktopExport :IReleaseScript2
    {
        //TODO: _workingMode should be configurable
        private ReleaseMode                 _workingMode    = ReleaseMode.MultiPage;
        private IDocumentOutputConverter    _docConverter   = null;
        private IPageOutputConverter        _pageConverter  = null;
        private string                      _exportFileName = string.Empty;

        public void CustomizeSettings(IList<IExporter> exporters, IJob job, IApplication licenseData)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            if (_workingMode == ReleaseMode.MultiPage)
                dialog.Filter = "PDF|*.pdf|TIFF|*.tif";
            else
                dialog.Filter = "BMP|*.bmp|JPEG|*.jpg|PDF|*.pdf|TIFF|*.tif";

            if (dialog.ShowDialog() != DialogResult.OK) return;

            _exportFileName = dialog.FileName;
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
            
        }

        public void EndDocument(IDocument doc, object handle, ReleaseResult result)
        {
            
        }

        public void EndRelease(object handle, ReleaseResult result)
        {
            
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
            _docConverter.Convert(doc, _exportFileName); 
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
            if (string.IsNullOrEmpty(_exportFileName))
                throw new Exception("Please specify a file name");

            foreach (IExporter exporter in exporters)
                if (exporter.DefaultExtension == Path.GetExtension(_exportFileName).ToUpper().TrimStart('.'))
                    if (_workingMode == ReleaseMode.SinglePage)
                        _pageConverter = exporter as IPageOutputConverter;
                    else
                        _docConverter = exporter as IDocumentOutputConverter;

            if (_pageConverter == null && _docConverter == null)
                throw new Exception("Please select an output file type");

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
            return null;
        } 
        #endregion
    }
}
