using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHillapaySdk
{
    void paymentResult(String ipgModel);
    void verifyResult(String verifyModel);
    void directDebitResult(String payModel);
    void ipgReportResult(String reportModel);
    void ipgReportLastListResult(String reportModel);
    void failedSDK(String errorModel);
}
