using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace PatientRegistrationandDischarge
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/RegisterPatient?inputString={inputString}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string RegisterPatient(string inputString);

        [OperationContract]
        [WebInvoke(Method = "Get", UriTemplate = "/DischargePatient?patientid={patientid}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string DischargePatient(string patientid);

        [OperationContract]
        [WebInvoke(Method = "Get", UriTemplate = "/LoadAllData", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<PatientDetails> SelectAllPatient();

        [OperationContract]
        [WebInvoke(Method = "Get", UriTemplate = "/LoadPatientData?patientid={patientId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string SelectPatient(string patientId);

    }
}
