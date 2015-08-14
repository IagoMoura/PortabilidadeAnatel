﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inovix.Service.ConsoleHost.KgbService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="KgbService.IKgbService")]
    public interface IKgbService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKgbService/GetCustomerByCPF", ReplyAction="http://tempuri.org/IKgbService/GetCustomerByCPFResponse")]
        Common.Contracts.Customer GetCustomerByCPF(string cpf);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKgbService/GetCustomerByCPF", ReplyAction="http://tempuri.org/IKgbService/GetCustomerByCPFResponse")]
        System.Threading.Tasks.Task<Common.Contracts.Customer> GetCustomerByCPFAsync(string cpf);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKgbService/ObterStatusFinanceiroCliente", ReplyAction="http://tempuri.org/IKgbService/ObterStatusFinanceiroClienteResponse")]
        Common.Contracts.Customer ObterStatusFinanceiroCliente(string cpf);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKgbService/ObterStatusFinanceiroCliente", ReplyAction="http://tempuri.org/IKgbService/ObterStatusFinanceiroClienteResponse")]
        System.Threading.Tasks.Task<Common.Contracts.Customer> ObterStatusFinanceiroClienteAsync(string cpf);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKgbService/ObterDadosConta", ReplyAction="http://tempuri.org/IKgbService/ObterDadosContaResponse")]
        Common.Contracts.Account ObterDadosConta(Common.Contracts.Customer customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKgbService/ObterDadosConta", ReplyAction="http://tempuri.org/IKgbService/ObterDadosContaResponse")]
        System.Threading.Tasks.Task<Common.Contracts.Account> ObterDadosContaAsync(Common.Contracts.Customer customer);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IKgbServiceChannel : Inovix.Service.ConsoleHost.KgbService.IKgbService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class KgbServiceClient : System.ServiceModel.ClientBase<Inovix.Service.ConsoleHost.KgbService.IKgbService>, Inovix.Service.ConsoleHost.KgbService.IKgbService {
        
        public KgbServiceClient() {
        }
        
        public KgbServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public KgbServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public KgbServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public KgbServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Common.Contracts.Customer GetCustomerByCPF(string cpf) {
            return base.Channel.GetCustomerByCPF(cpf);
        }
        
        public System.Threading.Tasks.Task<Common.Contracts.Customer> GetCustomerByCPFAsync(string cpf) {
            return base.Channel.GetCustomerByCPFAsync(cpf);
        }
        
        public Common.Contracts.Customer ObterStatusFinanceiroCliente(string cpf) {
            return base.Channel.ObterStatusFinanceiroCliente(cpf);
        }
        
        public System.Threading.Tasks.Task<Common.Contracts.Customer> ObterStatusFinanceiroClienteAsync(string cpf) {
            return base.Channel.ObterStatusFinanceiroClienteAsync(cpf);
        }
        
        public Common.Contracts.Account ObterDadosConta(Common.Contracts.Customer customer) {
            return base.Channel.ObterDadosConta(customer);
        }
        
        public System.Threading.Tasks.Task<Common.Contracts.Account> ObterDadosContaAsync(Common.Contracts.Customer customer) {
            return base.Channel.ObterDadosContaAsync(customer);
        }
    }
}
