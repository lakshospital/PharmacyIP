SELECT Isnull(SUM(total),0) AS Expr1 
FROM (SELECT  ESQty * (SELECT  i.HSR FROM InvoiceDetails i WHERE i.ProductName = d .productname 
AND i.BatchNo = d .batchno AND i.invoiceno = d.InvoiceNo AND year(i.invoicedatetime) = d.InvoiceYear) 
AS total FROM ESTable d WHERE (ProductName ='NOSOCEF INJ' and ESDate<'28/Mar/2022 12:00:00 AM' and ESType='Shortage'))
DERIVEDTBL

select top(1) * from InvoiceDetails  WHERE ProductName ='NOSOCEF INJ'  AND invoiceno = 799 and batchno=123

update top(1)  InvoiceDetails set Batchno=122  WHERE ProductName ='NOSOCEF INJ'  AND invoiceno = 799 and batchno=123 



SELECT * FROM [LaskhmiHospital].[dbo].[RoomDetails] order by RoomNo
SELECT * FROM [LaskhmiHospital].[dbo].[AdmissionDetails] ORDER BY ADMISSIONDATETIME DESC
 
SELECT RoomDetails.RoomNo, AdmissionDetails.IPNo, AdmissionDetails.PatientName, AdmissionDetails.Address,  
 AdmissionDetails.AdmissionDateTime FROM  RoomDetails INNER JOIN  AdmissionDetails 
ON RoomDetails.RoomNo = AdmissionDetails.RoomNo  
WHERE     (RoomDetails.Status = 'U') AND (AdmissionDetails.Status = 'A') 
AND (RoomDetails.RoomNo IN ('123 AC','125 AC','311 AC','A311AC','312 AC', '313 AC', '314 AC', '315 AC', '316 AC', '411 AC', '412 AC', 
'413 AC', '414 AC'))  ORDER BY RoomDetails.RoomNo