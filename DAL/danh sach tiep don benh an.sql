-- Tiếp đón bệnh nhân
select hm_receive_patient(';;;;;;0;Nguyễn;Thành;Công;1990-1-1;1990-1-1;26;1;1;17;9210318159999;9;;501;333;0;317;;;;O;-1;1;0;31180;;0;;0;;;0');
select hm_receive_patient(';;;;;;0;Nguyễn;Phú Gia Đạt;Thành;1990-1-1;1990-1-1;26;1;1;17;9210318159999;9;;501;333;0;317;;;;O;-1;1;0;31180;;0;;0;;;0');

-- Danh sách bệnh nhân
SELECT * FROM hm_exam_list_view;

-- Kham Benh click vao chi tiet tung benh nhan
SELECT *, his_general_full_address(homenumber, address, precinct_name) AS full_address, UPPER(full_name) AS full_name_upper, 0 AS is_card, 
CASE WHEN archives_number_home IS NOT NULL OR archives_number_home <> '' THEN 1 ELSE 0 END is_home_treatment_file, 
CASE WHEN medical_objects = 1 THEN CASE WHEN insurance_discount <> 0 THEN 'BH:' || insurance_discount || '%' ELSE '' END ELSE 
CASE WHEN medical_objects = 3 THEN 'Chính Sách' ELSE 'Thu Phí ' || (100 - object_remission) || '%' END END || 
CASE WHEN object_remission <> 0 THEN CASE WHEN insurance_discount = 0 THEN 'Miễn phí:' || object_remission || '%' ELSE '+' || 'Miễn :' || object_remission || '%' END ELSE '' END AS medical_object, 
CASE WHEN suggestion_policy = 9 THEN finish_plan_time::date + treatment_day ELSE CASE WHEN treatment_id <> 0 THEN finish_plan_time ELSE close_time END END AS date_signal 
FROM his_get_medical_info('16157147|0|0');

--- Lay thong tin nhap thuoc

 SELECT code FROM hms_drugselection 
 WHERE zone = 'stock' AND note IN ('NT','BL') AND othername = '1' 
 AND code IN (140,141,142,143,150,151,152,153,154,155,156,157,158,159,160,161,162,163,164,165,166,167,168,169,170,171,172,173,174,175,176,177,178,179,180,181,182,183,184,185,186,187,188,189,190,191,192,193,194,195,196,197,198,199,200,201,202,203,204,205,206,207,208,209,210,211,212,213,214,215,216,217,218,219,220,221,222,249,250,251,252,253,254,255,256,257,258,259,260,261,262,263,264,265,266,267,268,269,270,271,272,273,274,275,276,277,278,279,280,281,282,283,284,285,286,300,301,302,303,304,305,306,307,308,309,310,311,312,313,314,315,316,317,318,319,320,321,322,323,324,325,326,327,328,329,330,331,332,333,334,335,336,337,338,339,340,341,342,343,598,599) LIMIT 1;

--- Hiển thị chi tiết thông tin bệnh nhân view thuoc
 select a.id, drugname, content, unit, deliveredquantity as quantity, price, note, expireddate, stockimexid, usingdrugid, stockid , 
 deliveredquantity * price AS money, instruction, dailydosage, instalment, usage, usagename, 
 doctorid, doctorname, a.status, dosage, drug_accept, stockimexid, 0 AS chs 
 from hm_patientdrugview a 
 JOIN hm_employee b ON a.doctorid = b.id  
 where medicalrecordid = 16157145 order by a.id;

--- them thong tin nhap thuoc do thuoc
 SELECT * FROM his_test_drug_in('67212;16157145')
--- Tim thuốc nhập vào với 4 kí tự
 SELECT * FROM hm_drug_instock_view WHERE sname LIKE '%alph%' AND stockid = 599

 --- Ham add thong tin thuoc
 SELECT pharma_NewDrugPatient_DirectStock('16088832;16157145;599;501;0;67212;1;1.0;1.0;1;1;1;Mỗi Ngày 1 Lần, Mỗi Lần 1 Viên . . Uống trước bữa ăn;323;317;2640')

 --- Ham cho can lam sang xet nghiem ( view hien thi)
	 SELECT *, CASE WHEN status = 'T' THEN 1 ELSE 0 END AS chk FROM hm_paraclinical_doctor_view 
	 WHERE medicalrecordid = 16157145 AND category <> 'SUBITEM' ORDER BY servicedate, id DESC

-- Ham them can lam sang vao
select hm_fee_addnew_paraclinical('2016-11-27;16088832;16157145;501;3331;71834,70600;0;0;323;317;1;phu gia test phan mem;0')
select hm_fee_addnew_paraclinical('2016-11-27;16088832;16157145;501;282;70344;0;0;323;317;1;kt phu giá test kk;0')
-- Ham xoa can lam sang vao
SELECT hm_fee_delete_paraclinical('5589041;0;70600;317')

--- View thong tin thu thuat phau thuat	
SELECT * FROM his_medical_service_get('16157145|0')

--- Ham them thong tin can lam sang 
SELECT his_medical_service_set('16157145|501|323|70225|0|0|0|test thu thuat 222|317|[192.168.1.65]')
-- Ham xoa can lam sang
select his_medical_service_del('728590|317')

-- view thong tin benh nhan phong kham so 1
SELECT a.id AS medicalrecordid, hm_getname(fname, mname, null) fullname, lname AS name, a.status, 
CASE WHEN gender = 1 THEN 'Nam' ELSE 'Nữ' END AS sex, birthyear, c.code AS cardcode, 
CASE WHEN length(subjectofpatient::text) <> 9 THEN 0 ELSE substr(subjectofpatient::text,7,3)::integer END AS discount, age, b.id,  a.examroomid, d.id AS receptionid, d.status AS receptionstatus, ticketnumber, queuenumber, 0 AS chs
 FROM hms_medicalrecord a 
 JOIN hms_patient b ON a.patientid = b.id 
 LEFT JOIN hms_card c ON a.cardid = c.id 
 JOIN hms_reception d ON a.id = d.medicalrecordid  
 WHERE d.examroomid = 501  AND creationdate::date = current_date


-- Ham phieu hen tai kham
SELECT * FROM hm_medicalrecord_backhosp WHERE id = 16157145

-- Ham in don thuoc
SELECT drugname || '(' || origin || '/' || content || ')' AS fulldrugname, unit, sum(deliveredquantity) AS quantity, instruction, hm_getdoctorname_title(doctorid) AS doctorname, b.price, sum(deliveredquantity*b.price) AS money
FROM hms_patientdrug a JOIN hm_usingdrugview b ON a.usingdrugid = b.id 
WHERE medicalrecordid = 16157145 AND supplyid >= 500 
GROUP BY a.id, drugname, origin, content, unit, instruction, hm_getdoctorname_title(doctorid), b.price ORDER BY a.id

-- Ham lay id thuoc cao nhat	
SELECT id FROM hms_patientdrug WHERE medicalrecordid = 16157145 GROUP BY id LIMIT 1

--- Ham lay thong tin chan doan icd 10
 SELECT vnname FROM hms_icd10 WHERE icdcode = 'I10.1'::text AND hide = 0

-- Ham lay thong tin kem theo
 SELECT * FROM his_diagnoisic_get('16157145|4^5')

 -- Ham ket luan benh an
 SELECT * FROM hm_exam_conclusion WHERE id = 13405003
 SELECT * FROM hm_exam_conclusion WHERE id = 13405007
  SELECT hm_exam_conclude('13405007;16157149;2016-11-27;323;E11.22;1;5;0;5;0;317;0')

--- Ham tim kiem benh nhan
SELECT *, his_general_full_address(homenumber, address, precinct_name) AS full_address, 
UPPER(full_name) AS full_name_upper, 0 AS is_card, 
CASE WHEN archives_number_home IS NOT NULL OR archives_number_home <> '' THEN 1 ELSE 0 END is_home_treatment_file,
 CASE WHEN medical_objects = 1 THEN CASE WHEN insurance_discount <> 0 THEN 'BH:' || insurance_discount || '%' ELSE '' END ELSE 
 CASE WHEN medical_objects = 3 THEN 'Chính Sách' ELSE 'Thu Phí ' || (100 - object_remission) || '%' END END || 
 CASE WHEN object_remission <> 0 THEN CASE WHEN insurance_discount = 0 THEN 'Miễn phí:' || object_remission || '%' ELSE '+' || 'Miễn :' || object_remission || '%' END ELSE '' END AS medical_object, 
 CASE WHEN suggestion_policy = 9 THEN finish_plan_time::date + treatment_day ELSE 
 CASE WHEN treatment_id <> 0 THEN finish_plan_time ELSE close_time END END AS date_signal 
FROM his_get_medical_info('16157145|0|0')


-- Ham mo ho so
SELECT hm_tool_openmedicalrecord(16157145, False, 1, 317)


--- Nhap hoa don duoc
SELECT id, name || '-' || content AS drugname, content, unit FROM pharma_drug_view GROUP BY id, name || '-' || content, content, unit
SELECT id, supplierid, name, totalvalue, supplydate, invoice, deliverer, rateinterest, percentvat, storekeeperid, receiver, mainstockid, name, status FROM pharma_list_bill WHERE status = 'O'::text AND mainstockid = 150 AND invoicetype = 0
SELECT pharma_newMainImEx('2016-11-27;3012;gia;12345687;5;0;12345678;317;150;0')
ELECT * FROM hm_mainimexdetailview WHERE mainimexid = 16004174
SELECT pharma_newdrug_immainstock('16004174;9073;12600;;2018-11-27;34;1;1872;3012;12600;1000;317;45;0;458;0');