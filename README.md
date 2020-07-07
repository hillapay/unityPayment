# HillaPay

[![Hilla WebSite](https://img.shields.io/badge/WebSite-HillaVas-red.svg)](http://hillavas.com/)  


HillaPay Payment SDK is an effective and convenient way to implement a payment system to android apps and games. The SDK is working pretty fine with the Shetab Banking Network and all related cards. This payment SDK is Android-market-independent so that you may take benefit from it for a wide variety of use.

Some of the features of this payment SDK are as follows;
- There are two methods for making payments,
- it does not rely on dependencies,
- it is pretty small in size, and
- there is no other library in it.

Let's have a look at it.



## How to use

#### 1. Add dependencies

##### Add the dependency in your manifest.json project
```groovy
{
  "dependencies": {
   		 "ir.hillapay.core": "https://github.com/hillapay/unityPayment.git",
     }
}
```
#### 2. Add the "API Key" to Gradle

Go to the below path and copy the "GradleTemplate" file.

`UnityInstalationDirectory\Editor\Data\PlaybackEngines\AndroidPlayer\Tools\GradleTemplate`
Put the "GradleTemplate" file in `Assets > Plugins > Android`
and then open it and define the value of "defaultConfig{}" accordingly:

```groovy
defaultConfig {
        manifestPlaceholders = [HILLA_API_KEY: "Your key"]
}
```

in Unity, go to the `File > Build Setting > Player Setting`
and change the settings according to the below screenshot.

![](https://github.com/hillapay/unityPaymentFiles/blob/master/enableGradle.png)

Then go to the `File > Build Setting > Player Setting > Publishing Settings`
and activate "Custom Gradle Template".

![](https://github.com/hillapay/unityPaymentFiles/blob/master/enableTemplateGradle.png)

#### 3. Implement the SDK functions.
There are four functions to implement, which in various cases, each has a different result in SDK. Let's check each of these functions in details;

- PaymentResult Function: This function reflects the result of the "Payment" request. If the response is positive, it can handle the "verify" in the next step.
- VerifyResult Function: This function reflects the result of the "Verify" request. If the response is positive, it has successfully made the payment.
- DirectDebitResult Function: This function reflects the result of the "Direct Debit" request. If the response is positive, it has successfully made the payment.
- FailedSDK Function: This function is called whenever there is an error in the payment process; for instance, the internet disconnection, Server Errors, etc. The "ErrorMoldel" is the cause of the incomplete result. The value of ErrorModel is in the form of a JSON and reflects two values of "Type" and "Message". The "Type" is according to the below table, and the "Message" is the corresponding message text.

| Message  | Errortype  |
| :------------:  | :------------:  |
| unknown error | 0  |
| connection time out  |  1 |
|  server is down | 2  |
|  no internet connection |3 |
| no network connection  | 4  |
| can not pars json data | 5  |
|  address not found  | 6  |
| invalid params  | 7  |
| response error  |  8 |
| canceled by user  | 9  |
| null objects  | 10  |

These functions have STRING value in the form of JSON. 
You may take the benefit of JsonParser to use these inputs.


![Example of implementation of the SDK Function in the script of the sample project.](https://github.com/hillapay/unityPaymentFiles/blob/master/sampleScripte.png "Example of implementation of the SDK Function in the script of the sample project.")

`Example of implementation of the SDK Function in the script of the sample project.`

#### 4. Use of the methods  to make a payment

**1.Payment Function:** This function is for the first phase of the payment process; wherever you want to have payment, it is necessary to call this function first. 
The result of this function will be reflected in the "PaymentResult" function, described earlier.

```csharp
HillapaySdk. payment(gameObject, amount, phone, orderId, description, uid, additionalData,sku, phoneByUser)
```

<table>
<tr>
 <td>GameObject <td>This parameter is for the Script. (GameObject)
</tr>
<tr>
<td>Amount<td>The amount of the payment. (Long)
</tr>
<tr>
<td>Phone<td>The phone number. (String)
</tr>
<tr>
<td>OrderID<td>A unique ID that changes for each payment request, and in all of the payment processes, it should use the same OrderID. (Long)
</tr>
<tr>
<td>Description<td>The description of the payment. (String)
</tr>
<tr>
<td>UID<td>It is a unique ID that should be kept the same for all payments. (String)
</tr>
<tr>
<td>AdditionalData<td>It is to add more information to the payment. (String)
</tr>
<tr>
<td>SKU<td>It is the product code, that is used to control the payments. (String)
</tr>
<tr>
<td>PhoneByUser<td>You may ask the user's phone number; for this case, change the value to TRUE. By activating this filed, you may add an extra step to your payment process, and you ask for the user to input its phone number (Boolean).
</tr>
</table>

------------

**2.Verify Function:** You may use this function whenever the “PaymentResult” reflects the positive response.

```csharp
HillapaySdk. verify(gameObject, uid, ipgModel)
```
<table>
<tr>
 <td>GameObject <td>This parameter is for the Script. (GameObject)
</tr>
<tr>
 <td>UID <td>It is a unique ID that should be kept the same for all payments. (String)
 </tr>
 <tr>
 <td>IPGModel <td>It is the “Return Model” for the PaymentResult function. (String)
</tr>
</table>

------------

**3.isSuccessIpg Function:** It is to get the “is_success” for the ipgModel.

```csharp
HillapaySdk. isSuccessIpg(ipgModel)
```
<table>
<tr>
 <td>ipgModel<td>It is the “Return Model” for the PaymentResult function. (String)
</tr>
</table>

------------

**4.isSuccessVerify Function:** It is to get the “is_success” for the verifyModel.

```csharp
HillapaySdk. isSuccessVerify (verifyModel)
```
<table>
<tr>
 <td>verifyModel<td>It is the “Return Model” for the VerifyResult function. (String)
</tr>
</table>


------------

**5.isSuccessDirectdebit Function:** It is to get the “is_success” for the directdebitModel.

```csharp
HillapaySdk. isSuccessDirectdebit (directdebitModel)
```
<table>
<tr>
 <td>directdebitModel<td>It is the “Return Model” for the DirectDebitResult function. (String)
</tr>
</table>




#### 5. IPG Payments Reports

**1-** To have your IPG Payments Reports do accordingly:

![](https://github.com/hillapay/unityPaymentFiles/blob/master/ipgReport.png)

Add the above function to your script to return your request to this function.

<table>
<tr>
 <td>reportModel<td>It is the “Return Model” for the report in the form of JSON.
</tr>
</table>

Then call the below function for the report:

```csharp
HillapaySdk. getIpgReport (gameObject, uid)
```

**2-** The list of the last five payments

![](https://github.com/hillapay/unityPaymentFiles/blob/master/ipgReportList.png)

Add the above function to your script to return your request to this function.

<table>
<tr>
 <td>reportModel<td>It is the “Return Model” for the report in the form of JSON.
</tr>
</table>

Then call the below function for the report:

```csharp
HillapaySdk. getIpgLastReportList (gameObject, uid)
```

#### 6. You may change the below items in the “Manifest” to change the theme of the SDK

You may copy the “Manifest” file from the below path and put it in the folder of `Assets > Plugins > Android`  in your project.

The “Manifest” path:
`(unityProjectDirectory)\UnityTest\Temp\StagingArea`

Open the manifest file and update the below custom values in the “Application” Tag.

```xml
<meta-data
    android:name="ir.hillapay.core.BACKGROUND_MAIN"
    android:resource="@drawable/background_main" />
<meta-data
    android:name="ir.hillapay.core.BACKGROUND_MAIN2"
    android:resource="@drawable/background_main2" />
<meta-data
    android:name="ir.hillapay.core.LINE_COLOR"
    android:resource="@color/colorAccent" />
<meta-data
    android:name="ir.hillapay.core.POPUP_COLOR"
    android:resource="@color/colorAccent4" />

<meta-data
    android:name="ir.hillapay.core.BACKGROUND_SEEK_BAR"
    android:resource="@color/colorAccent4" />
<meta-data
    android:name="ir.hillapay.core.TEXT_COLOR"
    android:resource="@color/colorAccent3" />
<meta-data
    android:name="ir.hillapay.core.CURVED_BUTTON_SIZE"
    android:value="100" />
<meta-data
    android:name="ir.hillapay.core.FONT"
    android:value="fonts/hillafont.otf" />

```
>**BACKGROUND_MAIN** It is the color of all backgrounds, you can also use a photo in the background and load it from the “drawable” folder, and you can set color values in the “color” folder.

>**BACKGROUND_MAIN2** It is the color of all backgrounds, you can also use a photo in the background and load it from the “drawable” folder, and you can set color values in the “color” folder. 

>**LINE_COLOR** It is the color of lines you can set in the “drawable” folder, and you can set color values in the “color” folder.

>**POPUP_COLOR** It is the color of dialogue boxes that you can set it in the “drawable” folder, and you can set color values in the “colors” folder.

>**Background_Seek_Bar** This option allows you to change the background of the Price box; you can set it in the “drawable” folder, and also, you can set color values in the “colors” folder.

>**CURVED_BUTTON_SIZE** You can change the curve amount around the buttons with this option.

>**FONT** This option allows you to change the font of the SDK. Put your custom font in the “fonts” folder and name it in the settings.

It is required to put the “settings resource” in its correspondence folder in your project to use the above custom changes correctly.

Put “Drawable” files in the below path, and if there is no such folder, please create it.
`Assets > Plugins > Android > res > Drawable`

Put “Color” files in the below path, and if there is no such folder, please create it.
`Assets > Plugins > Android > res > values`

Put “Font” files in the below path, and if there is no such folder, please create it.
`Assets > Plugins > Android > res > Fonts`


#### 7.Implement Analytics Script

```csharp
HillapaySdk.init("uid")
```

or

```csharp
HillapaySdk.init("uid",showFirstLevel)
```

>**ShowFirstLevel:** It is a boolean value. If it is FALSE it means that different payment methods are only one method, and users do not see the screen of choosing among payment methods; it passes automatically. If it is set to TRUE, this step will be displayed to users.


**App Open:** Use the below to get noticed about the app open event.
```csharp
HillapaySdk.openTrack("uid")
```
**App Close:** Use the below to get noticed about the app close event.

```csharp
HillapaySdk. closeTrack ("uid")
```
**Track other parts of the app: **To track events related to other parts of the app, use the below method.
```csharp
HillapaySdk.tracker("uid", "action", "description")
```

You can see manifest, gradle, assets and resource sample by linke:

[https://github.com/hillapay/unityPaymentFiles/tree/master/sample%20template](https://github.com/hillapay/unityPaymentFiles/tree/master/sample%20template)



[hilla]: http://hillavas.com/ "Hillavas"
