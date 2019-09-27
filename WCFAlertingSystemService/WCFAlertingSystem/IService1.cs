using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;


namespace WCFAlertingSystem
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {   
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/MonitorVitals", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<PatientDetails> MonitorPatientVitals();


    }
}
