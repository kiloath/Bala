using System;
using System.Collections.Generic;
using System.Text;

namespace CAPIATL_Proxy
{
    public class CAPIATL_API
    {
        private ConcordsCAPIATLLib.ConcordsCAPI m_CAPI;

        public ConcordsCAPIATLLib.ConcordsCAPI CAPI
        {
            get
            {
                if (m_CAPI == null)
                {
                    m_CAPI = new ConcordsCAPIATLLib.ConcordsCAPI();
                }
                return m_CAPI;
            }
        }
        public String GetCertStatus(String strIDNO, out String strStartDate, out String strExpireDate, out String strMsg)
        {
            strIDNO = strIDNO.Trim().ToUpper();
            strStartDate = "";
            strExpireDate = "";
            string strSubject = "";

            String strMsgCode = "";
            try
            {
                strSubject = "CN=" + strIDNO + "\r\nOU=CONCORDS";
                string strCert = CAPI.CAPI_XGetUserCertificate("", strSubject, 2 | 0x00080000 | 0x00000010 | 0x00000004, 0x0080);
                int intRtnCode = CAPI.GetErrorCode();
                //int CGCAPI_FLAG_SELCERT_AFTER = 0x00000004;  //選擇日期最新的
                //int CGCAPI_FLAG_SELCERT_CHECKVALID = 0x00000010; //選擇有效憑證
                //int CGCAPI_FLAG_SELCERT_AUTO = 0x00000002; //自動挑選憑證
                //int CGCAPI_FLAG_SUBJECT_PARTIALMATCH = 0x00080000;  //與主體部分相符的憑證

                if (intRtnCode == 0)
                {
                    strStartDate = CAPI.CAPICertGetNotBefore(strCert, 0);//取得憑證起始日
                    strExpireDate = CAPI.CAPICertGetNotAfter(strCert, 0);//取得憑證到期日

                    strStartDate = strStartDate.Substring(0, 4) + "/" + strStartDate.Substring(4, 2) + "/" + strStartDate.Substring(6, 2) + " " +
                                   strStartDate.Substring(8, 2) + ":" + strStartDate.Substring(10, 2) + ":" + strStartDate.Substring(12, 2);

                    strExpireDate = strExpireDate.Substring(0, 4) + "/" + strExpireDate.Substring(4, 2) + "/" + strExpireDate.Substring(6, 2) + " " +
                                    strExpireDate.Substring(8, 2) + ":" + strExpireDate.Substring(10, 2) + ":" + strExpireDate.Substring(12, 2);

                    strMsgCode = "000";
                    strMsg = "成功";
                }
                else
                {
                    strMsgCode = "999";
                    strMsg = GetCertErrorMsg(intRtnCode);
                }
            }
            catch
            {
                strMsgCode = "999";
                strMsg = "取得憑證狀態失敗";
            }
            return strMsgCode;
        }

        public String GetCertErrorMsg(int ErrorCode)
        {
            string msg = "";
            switch (ErrorCode)
            {
                case 0:
                    msg = "完成";
                    break;
                case 5001:
                    msg = "[" + ErrorCode + "] 一般性錯誤";
                    break;
                case 5002:
                    msg = "[" + ErrorCode + "] 記憶體配置錯誤";
                    break;
                case 5003:
                    msg = "[" + ErrorCode + "] Buffer too small";
                    break;
                case 5005:
                    msg = "[" + ErrorCode + "] 參數錯誤";
                    break;
                case 5006:
                    msg = "[" + ErrorCode + "] Invalid handle";
                    break;
                case 5007:
                    msg = "[" + ErrorCode + "] 元件已過期";
                    break;
                case 5008:
                    msg = "[" + ErrorCode + "] Base64 Encoding/Decoding Error";
                    break;
                case 5010:
                    msg = "[" + ErrorCode + "] 找不到符合憑證";
                    break;
                case 5011:
                    msg = "[" + ErrorCode + "] 憑證已過期";
                    break;
                case 5012:
                    msg = "[" + ErrorCode + "] 憑證尚未有效";
                    break;
                case 5014:
                    msg = "[" + ErrorCode + "] 憑證主旨比對錯誤";
                    break;
                case 5015:
                    msg = "[" + ErrorCode + "] 找不到憑證發行者";
                    break;
                case 5016:
                    msg = "[" + ErrorCode + "] 憑證簽章值無效";
                    break;
                case 5017:
                    msg = "[" + ErrorCode + "] 錯誤的金鑰使用方式";
                    break;
                case 5020:
                case 5021:
                case 5022:
                case 5023:
                case 5024:
                case 5025:
                case 5026:
                case 5028:
                    msg = "[" + ErrorCode + "] 憑證已撤銷";
                    break;
                case 5030:
                    msg = "[" + ErrorCode + "] CRL 已過期";
                    break;
                case 5031:
                    msg = "[" + ErrorCode + "] CRL 尚未有效";
                    break;
                case 5032:
                    msg = "[" + ErrorCode + "] 找不到 CRL ";
                    break;
                case 5034:
                    msg = "[" + ErrorCode + "] CRL 的簽章值錯誤 ";
                    break;
                case 5036:
                    msg = "[" + ErrorCode + "] 資料的簽章值錯誤 ";
                    break;
                case 5037:
                    msg = "[" + ErrorCode + "] 簽章的原文錯誤 ";
                    break;
                case 5038:
                    msg = "[" + ErrorCode + "] 圖形驗證碼錯誤 ";
                    break;
                case 5040:
                    msg = "[" + ErrorCode + "] 錯誤的憑證格式 ";
                    break;

                case 5041:
                    msg = "[" + ErrorCode + "] 錯誤的 CRL 格式 ";
                    break;

                case 5042:
                    msg = "[" + ErrorCode + "] 錯誤的 PKCS#7 格式 ";
                    break;

                case 5050:
                    msg = "[" + ErrorCode + "] 找不到指定物件 ";
                    break;
                case 5071:
                    msg = "[" + ErrorCode + "] 密碼不正確 ";
                    break;

                case 5204:
                    msg = "[" + ErrorCode + "] 找不到私密金鑰 ";
                    break;
                case 5205:
                    msg = "[" + ErrorCode + "] 憑證無法匯出 ";
                    break;
                case 5206:
                    msg = "[" + ErrorCode + "] 權限不足 ";
                    break;
                case 5902:
                    msg = "[" + ErrorCode + "] 找不到檔案 ";
                    break;
                case 5906:
                    msg = "[" + ErrorCode + "] 沒有權限存取 ";
                    break;

                // PKCS#11 return code
                case 9005:
                    msg = "[" + ErrorCode + "] 此 PKCS#11 不支援此 Function ";
                    break;
                case 9006:
                    msg = "[" + ErrorCode + "] PKCS#11 參數錯誤 ";
                    break;
                case 9039:
                case 9040:
                    msg = "[" + ErrorCode + "] PKCS#11 Pin 碼錯誤 ";
                    break;
                case 9043:
                    msg = "[" + ErrorCode + "] PKCS#11 Pin Lock ";
                    break;
                case 9100:
                    msg = "[" + ErrorCode + "] 物件不存在 ";
                    break;
                case 9101:
                    msg = "[" + ErrorCode + "] 物件已存在 ";
                    break;
                case 9102:
                    msg = "[" + ErrorCode + "] 物件發生問題(可能是因為一個以上) ";
                    break;
                case 9110:
                case 9111:
                    msg = "[" + ErrorCode + "] Load Library 失敗 ";
                    break;
                case 9112:
                    msg = "[" + ErrorCode + "] 找不到 slot ";
                    break;
                default:
                    msg = "其他錯誤,請參考元件手冊";
                    break;
            }
            return msg;
        }
    }
}
