﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inovix.Service.ConsoleHost.AptService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AptService.IAptService")]
    public interface IAptService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAptService/SolicitarBilhetePortabilidade", ReplyAction="http://tempuri.org/IAptService/SolicitarBilhetePortabilidadeResponse")]
        Common.Contracts.Portability SolicitarBilhetePortabilidade(Common.Contracts.Customer customer, Common.Contracts.Account acount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAptService/SolicitarBilhetePortabilidade", ReplyAction="http://tempuri.org/IAptService/SolicitarBilhetePortabilidadeResponse")]
        System.Threading.Tasks.Task<Common.Contracts.Portability> SolicitarBilhetePortabilidadeAsync(Common.Contracts.Customer customer, Common.Contracts.Account acount);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAptServiceChannel : Inovix.Service.ConsoleHost.AptService.IAptService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AptServiceClient : System.ServiceModel.ClientBase<Inovix.Service.ConsoleHost.AptService.IAptService>, Inovix.Service.ConsoleHost.AptService.IAptService {
        
        public AptServiceClient() {
        }
        
        public AptServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AptServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AptServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AptServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Common.Contracts.Portability SolicitarBilhetePortabilidade(Common.Contracts.Customer customer, Common.Contracts.Account acount) {
            return base.Channel.SolicitarBilhetePortabilidade(customer, acount);
        }
        
        public System.Threading.Tasks.Task<Common.Contracts.Portability> SolicitarBilhetePortabilidadeAsync(Common.Contracts.Customer customer, Common.Contracts.Account acount) {
            return base.Channel.SolicitarBilhetePortabilidadeAsync(customer, acount);
        }
    }
}