using System;
using System.ServiceModel;

[ServiceContract]
interface IVisualStudioUser
{
    [OperationContract]
    string HelloWorld();
}
