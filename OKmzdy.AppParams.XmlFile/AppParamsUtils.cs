using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OKmzdy.AppParams.XmlFile
{
    public class AppParamsUtils
    {
        static readonly string REG_ROOT_OKM = "OKmzdy_pro_Windows";
        static readonly string REG_DATA_KON = "konfigurace";
        static readonly string REG_DATA_POL = "polozka";
        public static SoftwareMainData LoadOKmzdyMainRegistry(string paramXmlFile)
        {
            #region LOAD_XML_KONFIG
            XmlDocument paramXmlDoc = new XmlDocument();

            try
            {
                paramXmlDoc.Load(paramXmlFile);
            }
            catch (Exception ex)
            {
                string errorDiagnostics = string.Format("Exception loading file: {0}", ex.ToString());
                System.Diagnostics.Debug.Print(errorDiagnostics);
                return new SoftwareMainData();
            }

            #endregion

            StringBuilder bldNodeXPath = new StringBuilder("/*[local-name()='").Append(REG_ROOT_OKM).Append("']");

            string strNodeXPath = bldNodeXPath.ToString();

            return LoadOKmzdyMainRegistryItem(paramXmlDoc, strNodeXPath, REG_ROOT_OKM);
        }
        public static SoftwareUserData LoadOKmzdyDataRegistry(string paramXmlFile, string dataNode, string itemNode)
        {
            #region LOAD_XML_KONFIG
            XmlDocument paramXmlDoc = new XmlDocument();

            try
            {
                paramXmlDoc.Load(paramXmlFile);
            }
            catch (Exception ex)
            {
                string errorDiagnostics = string.Format("Exception loading file: {0}", ex.ToString());
                System.Diagnostics.Debug.Print(errorDiagnostics);
                return new SoftwareUserData();
            }

            #endregion

            StringBuilder bldNodeXPath = new StringBuilder("/*[local-name()='")
                .Append(REG_ROOT_OKM).Append("']/*[local-name()='").Append(dataNode)
                .Append("']/*[local-name()='").Append(REG_DATA_KON)
                .Append("' and @name='").Append(itemNode).Append("']");

            string strNodeXPath = bldNodeXPath.ToString();

            return LoadOKmzdyDataRegistryItem(paramXmlDoc, strNodeXPath, itemNode);
        }

        private static SoftwareMainData LoadOKmzdyMainRegistryItem(XmlDocument paramXmlDoc, string strNodeXPath, string dataMainNode)
        {
            SoftwareMainData appMainItem = new SoftwareMainData();

            if (paramXmlDoc == null)
            {
                appMainItem.Init();

                return appMainItem;
            }

            Int32 defaultZero = 0;

            appMainItem.ShortcutDesktop = GetValueInt32(paramXmlDoc, strNodeXPath, dataMainNode, SoftwareDataKeys.REG_ITEM_LNKDESK, defaultZero);
            appMainItem.AccessAceVers = GetValueInt32(paramXmlDoc, strNodeXPath, dataMainNode, SoftwareDataKeys.REG_ITEM_ACEVERS, defaultZero);

            appMainItem.ArchivFolder = GetValueString(paramXmlDoc, strNodeXPath, dataMainNode, SoftwareDataKeys.REG_ITEM_ARCFLDR, SoftwareDataKeys.EMPTY_STRING);
            appMainItem.DatabaseFolder = GetValueString(paramXmlDoc, strNodeXPath, dataMainNode, SoftwareDataKeys.REG_ITEM_DBSFLDR, SoftwareDataKeys.EMPTY_STRING);
            appMainItem.DatabaseName = GetValueString(paramXmlDoc, strNodeXPath, dataMainNode, SoftwareDataKeys.REG_ITEM_DBSNAME, SoftwareDataKeys.EMPTY_STRING);
            appMainItem.ParentFolder = GetValueString(paramXmlDoc, strNodeXPath, dataMainNode, SoftwareDataKeys.REG_ITEM_PARFLDR, SoftwareDataKeys.EMPTY_STRING);
            appMainItem.ShortcutFolder = GetValueString(paramXmlDoc, strNodeXPath, dataMainNode, SoftwareDataKeys.REG_ITEM_LNKFLDR, SoftwareDataKeys.EMPTY_STRING);
            appMainItem.SystemDB = GetValueString(paramXmlDoc, strNodeXPath, dataMainNode, SoftwareDataKeys.REG_ITEM_DBSSYST, SoftwareDataKeys.EMPTY_STRING);
            appMainItem.TiskyFolder = GetValueString(paramXmlDoc, strNodeXPath, dataMainNode, SoftwareDataKeys.REG_ITEM_TISFLDR, SoftwareDataKeys.EMPTY_STRING);
            appMainItem.MsSqlServ = GetValueString(paramXmlDoc, strNodeXPath, dataMainNode, SoftwareDataKeys.REG_ITEM_ODBCSRV, SoftwareDataKeys.EMPTY_STRING);
            appMainItem.MsSqlUser = GetValueString(paramXmlDoc, strNodeXPath, dataMainNode, SoftwareDataKeys.REG_ITEM_DBSUSER, SoftwareDataKeys.USER_NAME);
            appMainItem.MsSqlUserPsw = GetValueString(paramXmlDoc, strNodeXPath, dataMainNode, SoftwareDataKeys.REG_ITEM_DBSUPSW, SoftwareDataKeys.EMPTY_STRING);
            appMainItem.MsSqlOwnr = GetValueString(paramXmlDoc, strNodeXPath, dataMainNode, SoftwareDataKeys.REG_ITEM_DBSOWNR, SoftwareDataKeys.OWNER_NAME);
            appMainItem.MsSqlOwnrPsw = GetValueString(paramXmlDoc, strNodeXPath, dataMainNode, SoftwareDataKeys.REG_ITEM_DBSOPSW, SoftwareDataKeys.EMPTY_STRING);
            appMainItem.MsSqlSdba = GetValueString(paramXmlDoc, strNodeXPath, dataMainNode, SoftwareDataKeys.REG_ITEM_SDBUSER, SoftwareDataKeys.EMPTY_STRING);
            appMainItem.MsSqlSdbaPsw = GetValueString(paramXmlDoc, strNodeXPath, dataMainNode, SoftwareDataKeys.REG_ITEM_SDBPSSW, SoftwareDataKeys.EMPTY_STRING);
            appMainItem.MsSqlWksArch = GetValueString(paramXmlDoc, strNodeXPath, dataMainNode, SoftwareDataKeys.REG_ITEM_WKSARCH, SoftwareDataKeys.EMPTY_STRING);
            appMainItem.MsSqlSrvArch = GetValueString(paramXmlDoc, strNodeXPath, dataMainNode, SoftwareDataKeys.REG_ITEM_SRVARCH, SoftwareDataKeys.EMPTY_STRING);

            return appMainItem;
        }
        private static SoftwareUserData LoadOKmzdyDataRegistryItem(XmlDocument paramXmlDoc, string strNodeXPath, string dataItemNode)
        {
            SoftwareUserData appDataItem = new SoftwareUserData();

            if (paramXmlDoc == null)
            {
                appDataItem.Init();

                return appDataItem;
            }

            Int32 defaultZero = 0;
            Int32 defaultOnes = 1;
            Int32 defaultNegs = -1;

            appDataItem.AppNodeName = dataItemNode;

            appDataItem.AppUIcolors = GetValueInt32(paramXmlDoc, strNodeXPath, dataItemNode, SoftwareDataKeys.REG_ITEM_UICOLOR, defaultZero);
            appDataItem.DbsProvider = GetValueInt32(paramXmlDoc, strNodeXPath, dataItemNode, SoftwareDataKeys.REG_ITEM_DBSPROV, defaultZero);
            appDataItem.DbsProvVers = GetValueInt32(paramXmlDoc, strNodeXPath, dataItemNode, SoftwareDataKeys.REG_ITEM_ACEVERS, defaultZero);
            appDataItem.DbsExclusiv = GetValueInt32(paramXmlDoc, strNodeXPath, dataItemNode, SoftwareDataKeys.REG_ITEM_DBEXCLS, defaultOnes);
            appDataItem.DbsSysDBShr = GetValueInt32(paramXmlDoc, strNodeXPath, dataItemNode, SoftwareDataKeys.REG_ITEM_ENSHARE, defaultNegs);
            appDataItem.BitmapyTisk = GetValueInt32(paramXmlDoc, strNodeXPath, dataItemNode, SoftwareDataKeys.REG_ITEM_TISKBMP, defaultZero);

            appDataItem.DbsFileName = GetValueString(paramXmlDoc, strNodeXPath, dataItemNode, SoftwareDataKeys.REG_ITEM_DBSNAME, SoftwareDataKeys.EMPTY_STRING);
            appDataItem.DbsDSrcName = GetValueString(paramXmlDoc, strNodeXPath, dataItemNode, SoftwareDataKeys.REG_ITEM_ODBCDSN, SoftwareDataKeys.EMPTY_STRING);
            appDataItem.DbsSystemDB = GetValueString(paramXmlDoc, strNodeXPath, dataItemNode, SoftwareDataKeys.REG_ITEM_DBSSYST, SoftwareDataKeys.EMPTY_STRING);
            appDataItem.DbsConnServ = GetValueString(paramXmlDoc, strNodeXPath, dataItemNode, SoftwareDataKeys.REG_ITEM_ODBCSRV, SoftwareDataKeys.EMPTY_STRING);
            appDataItem.DbsConnUser = GetValueString(paramXmlDoc, strNodeXPath, dataItemNode, SoftwareDataKeys.REG_ITEM_DBSUSER, SoftwareDataKeys.USER_NAME);
            appDataItem.DbsConnUPsw = GetValueString(paramXmlDoc, strNodeXPath, dataItemNode, SoftwareDataKeys.REG_ITEM_DBSUPSW, SoftwareDataKeys.EMPTY_STRING);
            appDataItem.DbsDschOwnr = GetValueString(paramXmlDoc, strNodeXPath, dataItemNode, SoftwareDataKeys.REG_ITEM_DBSOWNR, SoftwareDataKeys.OWNER_NAME);
            appDataItem.DbsDschOPsw = GetValueString(paramXmlDoc, strNodeXPath, dataItemNode, SoftwareDataKeys.REG_ITEM_DBSOPSW, SoftwareDataKeys.EMPTY_STRING);
            appDataItem.SouboryArch = GetValueString(paramXmlDoc, strNodeXPath, dataItemNode, SoftwareDataKeys.REG_ITEM_DBSARCH, SoftwareDataKeys.EMPTY_STRING);
            appDataItem.SouboryBkup = GetValueString(paramXmlDoc, strNodeXPath, dataItemNode, SoftwareDataKeys.REG_ITEM_DBSBKUP, SoftwareDataKeys.EMPTY_STRING);
            appDataItem.SouboryTisk = GetValueString(paramXmlDoc, strNodeXPath, dataItemNode, SoftwareDataKeys.REG_ITEM_PRNFILE, SoftwareDataKeys.EMPTY_STRING);
            appDataItem.SouboryTXML = GetValueString(paramXmlDoc, strNodeXPath, dataItemNode, SoftwareDataKeys.REG_ITEM_XMLFILE, SoftwareDataKeys.EMPTY_STRING);
            appDataItem.SouboryTPDF = GetValueString(paramXmlDoc, strNodeXPath, dataItemNode, SoftwareDataKeys.REG_ITEM_PDFFILE, SoftwareDataKeys.EMPTY_STRING);
            appDataItem.SouboryTXLS = GetValueString(paramXmlDoc, strNodeXPath, dataItemNode, SoftwareDataKeys.REG_ITEM_XLSFILE, SoftwareDataKeys.EMPTY_STRING);
            appDataItem.CmdLineExpt = GetValueString(paramXmlDoc, strNodeXPath, dataItemNode, SoftwareDataKeys.REG_ITEM_DBSCMDE, SoftwareDataKeys.EMPTY_STRING);
            appDataItem.CmdLineImpt = GetValueString(paramXmlDoc, strNodeXPath, dataItemNode, SoftwareDataKeys.REG_ITEM_DBSCMDI, SoftwareDataKeys.EMPTY_STRING);
            appDataItem.DbfDrivImpt = GetValueString(paramXmlDoc, strNodeXPath, dataItemNode, SoftwareDataKeys.REG_ITEM_ODBCDBF, SoftwareDataKeys.FOXBASE_DRIVER);
            appDataItem.ExpUMuvozov = GetValueString(paramXmlDoc, strNodeXPath, dataItemNode, SoftwareDataKeys.REG_ITEM_EXUMUVZ, SoftwareDataKeys.QUOTES);

            appDataItem.DbsHRLink = GetValueInt32(paramXmlDoc, strNodeXPath, dataItemNode, SoftwareDataKeys.REG_ITEM_DBSHRMG, defaultZero);
            appDataItem.RemovePrac = GetValueInt32(paramXmlDoc, strNodeXPath, dataItemNode, SoftwareDataKeys.REG_ITEM_REMPRAC, defaultZero);

            return appDataItem;
        }

        private static Int32 GetValueInt32(XmlDocument xmlConfig, string nodeXPath, string nodeConfig, string keyLabel, Int32 defaultValue)
        {
            StringBuilder bldNodeXPath = new StringBuilder(nodeXPath)
                .Append("/*[local-name()='").Append(REG_DATA_POL)
                .Append("' and @name='").Append(keyLabel).Append("']/@value");

            string strNodeXPath = bldNodeXPath.ToString();

            try
            {
                XmlNode xmlNodeValue = xmlConfig.SelectSingleNode(strNodeXPath);

                if (xmlNodeValue == null)
                {
                    return defaultValue;
                }

                string strNodeValue = xmlNodeValue.InnerText;

                if (strNodeValue == SoftwareDataKeys.EMPTY_STRING)
                {
                    return defaultValue;
                }
                Int32 numNodeValue = defaultValue;

                if (Int32.TryParse(strNodeValue, out numNodeValue)==false)
                {
                    return defaultValue;
                }
                return numNodeValue;
            }
            catch (Exception ex)
            {
                string errorDiagnostics = string.Format("Exception in NODE {0}:\n{1}", nodeConfig, ex.ToString());
                System.Diagnostics.Debug.Print(errorDiagnostics);
            }
            return defaultValue;
        }

        private static string GetValueString(XmlDocument xmlConfig, string nodeXPath, string nodeConfig, string keyLabel, string defaultValue)
        {
            StringBuilder bldNodeXPath = new StringBuilder(nodeXPath)
                .Append("/*[local-name()='").Append(REG_DATA_POL)
                .Append("' and @name='").Append(keyLabel).Append("']/@value");

            string strNodeXPath = bldNodeXPath.ToString();

            try
            {
                XmlNode xmlNodeValue = xmlConfig.SelectSingleNode(strNodeXPath);

                if (xmlNodeValue == null)
                {
                    return defaultValue;
                }

                string strNodeValue = xmlNodeValue.InnerText;

                if (strNodeValue == SoftwareDataKeys.EMPTY_STRING)
                {
                    return defaultValue;
                }
                return xmlNodeValue.InnerText;
            }
            catch (Exception ex)
            {
                string errorDiagnostics = string.Format("Exception in NODE {0}:\n{1}", nodeConfig, ex.ToString());
                System.Diagnostics.Debug.Print(errorDiagnostics);
            }
            return defaultValue;
        }
    }
}
