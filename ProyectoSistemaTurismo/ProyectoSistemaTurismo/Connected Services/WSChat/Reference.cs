﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoSistemaTurismo.WSChat {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WSChat.WebService1Soap")]
    public interface WebService1Soap {
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento input del espacio de nombres http://tempuri.org/ no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InteractuarConChatbot", ReplyAction="*")]
        ProyectoSistemaTurismo.WSChat.InteractuarConChatbotResponse InteractuarConChatbot(ProyectoSistemaTurismo.WSChat.InteractuarConChatbotRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InteractuarConChatbot", ReplyAction="*")]
        System.Threading.Tasks.Task<ProyectoSistemaTurismo.WSChat.InteractuarConChatbotResponse> InteractuarConChatbotAsync(ProyectoSistemaTurismo.WSChat.InteractuarConChatbotRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class InteractuarConChatbotRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="InteractuarConChatbot", Namespace="http://tempuri.org/", Order=0)]
        public ProyectoSistemaTurismo.WSChat.InteractuarConChatbotRequestBody Body;
        
        public InteractuarConChatbotRequest() {
        }
        
        public InteractuarConChatbotRequest(ProyectoSistemaTurismo.WSChat.InteractuarConChatbotRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class InteractuarConChatbotRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string input;
        
        public InteractuarConChatbotRequestBody() {
        }
        
        public InteractuarConChatbotRequestBody(string input) {
            this.input = input;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class InteractuarConChatbotResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="InteractuarConChatbotResponse", Namespace="http://tempuri.org/", Order=0)]
        public ProyectoSistemaTurismo.WSChat.InteractuarConChatbotResponseBody Body;
        
        public InteractuarConChatbotResponse() {
        }
        
        public InteractuarConChatbotResponse(ProyectoSistemaTurismo.WSChat.InteractuarConChatbotResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class InteractuarConChatbotResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string InteractuarConChatbotResult;
        
        public InteractuarConChatbotResponseBody() {
        }
        
        public InteractuarConChatbotResponseBody(string InteractuarConChatbotResult) {
            this.InteractuarConChatbotResult = InteractuarConChatbotResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebService1SoapChannel : ProyectoSistemaTurismo.WSChat.WebService1Soap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebService1SoapClient : System.ServiceModel.ClientBase<ProyectoSistemaTurismo.WSChat.WebService1Soap>, ProyectoSistemaTurismo.WSChat.WebService1Soap {
        
        public WebService1SoapClient() {
        }
        
        public WebService1SoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ProyectoSistemaTurismo.WSChat.InteractuarConChatbotResponse ProyectoSistemaTurismo.WSChat.WebService1Soap.InteractuarConChatbot(ProyectoSistemaTurismo.WSChat.InteractuarConChatbotRequest request) {
            return base.Channel.InteractuarConChatbot(request);
        }
        
        public string InteractuarConChatbot(string input) {
            ProyectoSistemaTurismo.WSChat.InteractuarConChatbotRequest inValue = new ProyectoSistemaTurismo.WSChat.InteractuarConChatbotRequest();
            inValue.Body = new ProyectoSistemaTurismo.WSChat.InteractuarConChatbotRequestBody();
            inValue.Body.input = input;
            ProyectoSistemaTurismo.WSChat.InteractuarConChatbotResponse retVal = ((ProyectoSistemaTurismo.WSChat.WebService1Soap)(this)).InteractuarConChatbot(inValue);
            return retVal.Body.InteractuarConChatbotResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ProyectoSistemaTurismo.WSChat.InteractuarConChatbotResponse> ProyectoSistemaTurismo.WSChat.WebService1Soap.InteractuarConChatbotAsync(ProyectoSistemaTurismo.WSChat.InteractuarConChatbotRequest request) {
            return base.Channel.InteractuarConChatbotAsync(request);
        }
        
        public System.Threading.Tasks.Task<ProyectoSistemaTurismo.WSChat.InteractuarConChatbotResponse> InteractuarConChatbotAsync(string input) {
            ProyectoSistemaTurismo.WSChat.InteractuarConChatbotRequest inValue = new ProyectoSistemaTurismo.WSChat.InteractuarConChatbotRequest();
            inValue.Body = new ProyectoSistemaTurismo.WSChat.InteractuarConChatbotRequestBody();
            inValue.Body.input = input;
            return ((ProyectoSistemaTurismo.WSChat.WebService1Soap)(this)).InteractuarConChatbotAsync(inValue);
        }
    }
}
