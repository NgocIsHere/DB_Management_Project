--SELECT VALUE FROM v$option WHERE parameter = 'Oracle Label Security';
BEGIN
    SA_POLICY_ADMIN.REMOVE_TABLE_POLICY('AGENCY_POLICY','ADMIN_OLS','PROJECT_OLS_THONGBAO');
END;
/
BEGIN
  SA_SYSDBA.DROP_POLICY(
    policy_name => 'agency_policy'
  );
END;
/



BEGIN
 SA_SYSDBA.CREATE_POLICY(
 policy_name => 'agency_policy',
 column_name => 'agency_label'
);
END; 
/

EXEC SA_SYSDBA.ENABLE_POLICY ('agency_policy'); 
--TẠO COMPONENT CỦA LABEL 
--->TẠO LEVEL
EXECUTE SA_COMPONENTS.CREATE_LEVEL('agency_policy',20,'SV','P_SINHVIEN');
EXECUTE SA_COMPONENTS.CREATE_LEVEL('agency_policy',40,'NV','P_NVCOBAN');
EXECUTE SA_COMPONENTS.CREATE_LEVEL('agency_policy',60,'GVU','P_GIAOVU');
EXECUTE SA_COMPONENTS.CREATE_LEVEL('agency_policy',80,'GV','P_GIANGVIEN');
EXECUTE SA_COMPONENTS.CREATE_LEVEL('agency_policy',100,'TDV','P_TRUONGDONVI');
EXECUTE SA_COMPONENTS.CREATE_LEVEL('agency_policy',120,'TK','P_TRUONGKHOA'); 

--->TẠO COMPARTMENT
EXECUTE SA_COMPONENTS.CREATE_COMPARTMENT('agency_policy',20,'HTTT','Information System');
EXECUTE SA_COMPONENTS.CREATE_COMPARTMENT('agency_policy',40,'CNPM','Software Engineering'); 
EXECUTE SA_COMPONENTS.CREATE_COMPARTMENT('agency_policy',60,'KHMT','Computer Science');
EXECUTE SA_COMPONENTS.CREATE_COMPARTMENT('agency_policy',80,'CNTT','Knowledge Technology'); 
EXECUTE SA_COMPONENTS.CREATE_COMPARTMENT('agency_policy',100,'TGMT','Computer Vision');
EXECUTE SA_COMPONENTS.CREATE_COMPARTMENT('agency_policy',120,'MMT','Computer Network'); 

--->TẠO GROUP
EXECUTE SA_COMPONENTS.CREATE_GROUP('agency_policy',50,'CS1','AGENCY1');
EXECUTE SA_COMPONENTS.CREATE_GROUP('agency_policy',100,'CS2','AGENCY2');

--===========================TEST CHUYỂN PDB=======================================
----====================XÓA BẢNG=======================================
BEGIN
    EXECUTE IMMEDIATE 'ALTER TABLE PROJECT_NHANSU DROP CONSTRAINT FK_NS_DV'; 
EXCEPTION
   WHEN OTHERS THEN
      IF SQLCODE != -02443 THEN
         RAISE;
      END IF;
END;
/
BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE ' || 'PROJECT_DANGKY';
    EXECUTE IMMEDIATE 'DROP TABLE ' || 'PROJECT_PHANCONG'; 
    EXECUTE IMMEDIATE 'DROP TABLE ' || 'PROJECT_KHMO';
    EXECUTE IMMEDIATE 'DROP TABLE ' || 'PROJECT_HOCPHAN';
    EXECUTE IMMEDIATE 'DROP TABLE ' || 'PROJECT_SINHVIEN'; 
    EXECUTE IMMEDIATE 'DROP TABLE ' || 'PROJECT_DONVI'; 
    EXECUTE IMMEDIATE 'DROP TABLE ' || 'PROJECT_NHANSU'; 
    EXECUTE IMMEDIATE 'DROP TABLE ' || 'PROJECT_OLS_THONGBAO'; 
EXCEPTION
   WHEN OTHERS THEN
      IF SQLCODE != -942 THEN
         RAISE;
      END IF;
END;
/
--===========================XÓA ROLE==============================
BEGIN
    EXECUTE IMMEDIATE 'DROP ROLE ' || 'P_NVCOBAN'; 
    EXECUTE IMMEDIATE 'DROP ROLE ' || 'P_GIANGVIEN'; 
    EXECUTE IMMEDIATE 'DROP ROLE ' || 'P_GIAOVU'; 
    EXECUTE IMMEDIATE 'DROP ROLE ' || 'P_TRUONGDONVI'; 
    EXECUTE IMMEDIATE 'DROP ROLE ' || 'P_TRUONGKHOA'; 
    EXECUTE IMMEDIATE 'DROP ROLE ' || 'P_SINHVIEN'; 
EXCEPTION
   WHEN OTHERS THEN
      IF SQLCODE != -1919 THEN
         RAISE;
      END IF;
END;
/
--====================TẠO BẢNG=======================================
CREATE TABLE PROJECT_NHANSU
(
    MANV VARCHAR(10),
    HOTEN NVARCHAR2(100),
    PHAI NVARCHAR2(10),
    NGSINH DATE,
    PHUCAP INT,
    DT VARCHAR(10),
    VAITRO VARCHAR2(100),
    MADV VARCHAR(10),
    USERNAME VARCHAR(100),
    
    PRIMARY KEY(MANV)
);

CREATE TABLE PROJECT_SINHVIEN
(
    MASV VARCHAR(10),
    HOTEN NVARCHAR2(100),
    PHAI NVARCHAR2(10),
    NGSINH DATE,
    DCHI NVARCHAR2(100),
    DT VARCHAR(10),
    MACT VARCHAR(10),
    MANGANH VARCHAR(10),
    SOTCTL INT,
    DTBTL FLOAT,
    
    PRIMARY KEY(MASV)
);
CREATE TABLE PROJECT_DONVI
(
    MADV VARCHAR(10),
    TENDV NVARCHAR2(100),
    TRGDV VARCHAR(10),
    PRIMARY KEY(MADV)
);

CREATE TABLE PROJECT_HOCPHAN
(
    MAHP VARCHAR(10),
    TENHP NVARCHAR2(100),
    SOTC INT,
    SSLT INT,
    STTH INT, 
    SOSVTD INT,
    MADV VARCHAR(10),
    
    PRIMARY KEY(MAHP)
);

CREATE TABLE PROJECT_KHMO
(
    MAHP VARCHAR(10),
    HK INT,
    NAM INT,
    MACT VARCHAR(10),
    PRIMARY KEY(MAHP, HK,NAM,MACT)
);

CREATE TABLE PROJECT_PHANCONG
(
    MAGV VARCHAR(10),
    MAHP VARCHAR(10),
    HK INT,
    NAM INT,
    MACT VARCHAR(10),
    
    PRIMARY KEY(MAGV,MAHP,HK,NAM,MACT)
);
CREATE TABLE PROJECT_DANGKY
(
    MASV VARCHAR(10),
    MAGV VARCHAR(10),
    MAHP VARCHAR(10),
    HK INT, 
    NAM INT,
    MACT VARCHAR(10),
    DIEMTH FLOAT,
    DIEMQT FLOAT,
    DIEMCK FLOAT,
    DIEMTK FLOAT,
    
    PRIMARY KEY(MASV,MAGV,MAHP,HK,NAM,MACT)
);

ALTER TABLE PROJECT_NHANSU
ADD
    CONSTRAINT FK_NS_DV
    FOREIGN KEY (MADV)
    REFERENCES PROJECT_DONVI;

ALTER TABLE PROJECT_DONVI
ADD
    CONSTRAINT FK_DV_NS
    FOREIGN KEY (TRGDV)
    REFERENCES PROJECT_NHANSU;
    
ALTER TABLE PROJECT_HOCPHAN
ADD
    CONSTRAINT FK_HP_DV
    FOREIGN KEY (MADV)
    REFERENCES PROJECT_DONVI;
    
ALTER TABLE PROJECT_KHMO
ADD
    CONSTRAINT FK_KHMO_HP
    FOREIGN KEY (MAHP)
    REFERENCES PROJECT_HOCPHAN;
    
ALTER TABLE PROJECT_PHANCONG
ADD
    CONSTRAINT FK_PC_NS
    FOREIGN KEY (MAGV)
    REFERENCES PROJECT_NHANSU;

ALTER TABLE PROJECT_PHANCONG
ADD
    CONSTRAINT FK_PC_KHMO
    FOREIGN KEY (MAHP,HK,NAM,MACT)
    REFERENCES PROJECT_KHMO;  

ALTER TABLE PROJECT_DANGKY
ADD
    CONSTRAINT FK_DK_SV
    FOREIGN KEY (MASV)
    REFERENCES PROJECT_SINHVIEN;

ALTER TABLE PROJECT_DANGKY
ADD
    CONSTRAINT FK_DK_PC
    FOREIGN KEY (MAGV,MAHP,HK,NAM,MACT)
    REFERENCES PROJECT_PHANCONG;    

CREATE ROLE P_NVCOBAN;
CREATE ROLE P_GIANGVIEN;
CREATE ROLE P_GIAOVU;
CREATE ROLE P_TRUONGDONVI;
CREATE ROLE P_TRUONGKHOA;
CREATE ROLE P_SINHVIEN;
--=================================================================================
CREATE TABLE PROJECT_OLS_THONGBAO
(
    ID NUMBER(10), 
    NGAYTHONGBAO DATE,
    CONTENT NVARCHAR2(1000),
    MESSAGE NVARCHAR2(2000),
    
    PRIMARY KEY(ID)
);


INSERT INTO PROJECT_OLS_THONGBAO VALUES(1,to_date('2023-2-22','YYYY-MM-DD'), 'THONG BAO NAY DANH CHO TDV',N'Các trưởng bộ môn nhắc nhở nhân viên của mình hòan tất điểm thi cho sinh viên trước 0h ngày 5/3/2023');
INSERT INTO PROJECT_OLS_THONGBAO VALUES(2,to_date('2023-3-24','YYYY-MM-DD'), 'THONG BAO NAY DANH CHO SINH VIEN NGANH HTTT CS1',N'Các bạn sinh viên chú ý hoàn tất khảo sát đánh giá môn học cũng như tiền học phí');
INSERT INTO PROJECT_OLS_THONGBAO VALUES(3,to_date('2023-4-24','YYYY-MM-DD'), 'THONG BAO NAY DANH CHO TRUONG BO MON KHMT CUA CO SO 1',N'Trưởng bộ môn khoa học máy tính trực thuộc cơ sở 1 chú ý nộp đề tài dự án nghiên cứu mới cho giám đốc tại phòng giám đốc trước 0 h ngày 25/4/2023');
INSERT INTO PROJECT_OLS_THONGBAO VALUES(4,to_date('2023-2-15','YYYY-MM-DD'), 'THONG BAO NAY DANH CHO TRUONG BO MON KHMT CUA 2 CO SO',N'Các trưởng bộ môn khoa học máy tính của 2 cơ sở triển khai hướng dẫn sinh viên thực hiện đề tài tốt nghiệp');
INSERT INTO PROJECT_OLS_THONGBAO VALUES(5,to_date('2023-2-27','YYYY-MM-DD'), 'THONG BAO NAY DANH CHO TOAN BO GIANG VIEN CO SO 2',N'Các giảng viên cơ cở sở 2 thực hiện cho học sinh nghỉ học vào ngày 29/2/2023 để nhường phòng cho các giám khảo coi thi');
INSERT INTO PROJECT_OLS_THONGBAO VALUES(6,to_date('2023-6-28','YYYY-MM-DD'), 'THONG BAO NAY DANH CHO GIAO VU',N'Các giáo vụ nôpj hồ sơ tài chính về lên phòng giám độsc trước 0h ngày 30/6/2023');
INSERT INTO PROJECT_OLS_THONGBAO VALUES(7,to_date('2023-9-12','YYYY-MM-DD'), 'THONG BAO NAY DANH CHO TRUONG BO MON CNPM CO SO 1 VA CO SO 2',N'Các trưởng bộ môn Công Nghệ Phần Mềm của 2 cơ sở triển khai hướng dẫn sinh viên thực hiện đề tài tốt nghiệp');

GRANT SELECT ON PROJECT_OLS_THONGBAO TO P_NVCOBAN,P_GIAOVU,P_GIANGVIEN,P_TRUONGDONVI,P_TRUONGKHOA,P_SINHVIEN;
/
--B7: CẬP NHẬT NHÃN TRONG BẢNG
BEGIN
 SA_POLICY_ADMIN.REMOVE_TABLE_POLICY('AGENCY_POLICY','ADMIN_OLS','PROJECT_OLS_THONGBAO');

 SA_POLICY_ADMIN.APPLY_TABLE_POLICY (
 POLICY_NAME => 'AGENCY_POLICY',
 SCHEMA_NAME => 'ADMIN_OLS',
 TABLE_NAME => 'PROJECT_OLS_THONGBAO',
 TABLE_OPTIONS => 'NO_CONTROL'
 );
END; 
/
SELECT * FROM ADMIN_OLS.PROJECT_OLS_THONGBAO;
/

BEGIN
    SA_LABEL_ADMIN.CREATE_LABEL (
        policy_name  => 'AGENCY_POLICY',
        label_tag    => 1100,
        label_value  => 'TDV', -- SENSITIVE level for the HR compartment
        data_label   => TRUE);
    
    SA_LABEL_ADMIN.CREATE_LABEL (
        policy_name  => 'AGENCY_POLICY',
        label_tag    => 1200,
        label_value  => 'SV:HTTT:CS1', -- HIGHLY_SENSITIVE level for the HR compartment
        data_label   => TRUE);
    SA_LABEL_ADMIN.CREATE_LABEL (
        policy_name  => 'AGENCY_POLICY',
        label_tag    => 1300,
        label_value  => 'TDV:KHMT:CS1', -- HIGHLY_SENSITIVE level for the HR compartment
        data_label   => TRUE);
    SA_LABEL_ADMIN.CREATE_LABEL (
        policy_name  => 'AGENCY_POLICY',
        label_tag    => 1400,
        label_value  => 'TDV:KHMT:CS1,CS2', -- HIGHLY_SENSITIVE level for the HR compartment
        data_label   => TRUE);
    SA_LABEL_ADMIN.CREATE_LABEL (
        policy_name  => 'AGENCY_POLICY',
        label_tag    => 1500,
        label_value  => 'GV::CS2', -- HIGHLY_SENSITIVE level for the HR compartment
        data_label   => TRUE);
    SA_LABEL_ADMIN.CREATE_LABEL (
        policy_name  => 'AGENCY_POLICY',
        label_tag    => 1600,
        label_value  => 'GVU', -- HIGHLY_SENSITIVE level for the HR compartment
        data_label   => TRUE);
    SA_LABEL_ADMIN.CREATE_LABEL (
        policy_name  => 'AGENCY_POLICY',
        label_tag    => 1700,
        label_value  => 'TDV:CNPM:CS1,CS2', -- HIGHLY_SENSITIVE level for the HR compartment
        data_label   => TRUE);
END;
/

UPDATE ADMIN_OLS.PROJECT_OLS_THONGBAO
SET AGENCY_LABEL = CHAR_TO_LABEL('AGENCY_POLICY','TDV')
WHERE ID = 1;
UPDATE ADMIN_OLS.PROJECT_OLS_THONGBAO
SET AGENCY_LABEL = CHAR_TO_LABEL('AGENCY_POLICY','SV:HTTT:CS1')
WHERE ID = 2;
UPDATE ADMIN_OLS.PROJECT_OLS_THONGBAO
SET AGENCY_LABEL = CHAR_TO_LABEL('AGENCY_POLICY','TDV:KHMT:CS1')
WHERE ID = 3;
UPDATE ADMIN_OLS.PROJECT_OLS_THONGBAO
SET AGENCY_LABEL = CHAR_TO_LABEL('AGENCY_POLICY','TDV:KHMT:CS1,CS2')
WHERE ID = 4;
UPDATE ADMIN_OLS.PROJECT_OLS_THONGBAO
SET AGENCY_LABEL = CHAR_TO_LABEL('AGENCY_POLICY','GV::CS2')
WHERE ID = 5;
UPDATE ADMIN_OLS.PROJECT_OLS_THONGBAO
SET AGENCY_LABEL = CHAR_TO_LABEL('AGENCY_POLICY','GVU')
WHERE ID = 6;
UPDATE ADMIN_OLS.PROJECT_OLS_THONGBAO
SET AGENCY_LABEL = CHAR_TO_LABEL('AGENCY_POLICY','TDV:CNPM:CS1,CS2')
WHERE ID = 7;
--
--UPDATE PROJECT_OLS_THONGBAO
--SET AGENCY_LABEL = CHAR_TO_LABEL('AGENCY_POLICY','TK::');



BEGIN
SA_POLICY_ADMIN.REMOVE_TABLE_POLICY('AGENCY_POLICY','ADMIN_OLS','PROJECT_OLS_THONGBAO');

SA_POLICY_ADMIN.APPLY_TABLE_POLICY (
 policy_name => 'AGENCY_POLICY',
 schema_name => 'ADMIN_OLS',
 table_name => 'PROJECT_OLS_THONGBAO',
 table_options => 'READ_CONTROL',
predicate => NULL
);
END; 

--drop user GIAOVU cascade;
--drop user TRUONGKHOA cascade;
--drop user TRUONGBOMON CASCADE;
--drop user GIANGVIEN CASCADE;
CREATE USER GIAOVU IDENTIFIED BY 123;
GRANT CONNECT TO GIAOVU;
GRANT SELECT ON ADMIN_OLS.PROJECT_OLS_THONGBAO TO GIAOVU;


CREATE USER TRUONGKHOA IDENTIFIED BY 123;
GRANT CONNECT TO TRUONGKHOA;
GRANT SELECT ON ADMIN_OLS.PROJECT_OLS_THONGBAO TO TRUONGKHOA;

CREATE USER TRUONGBOMON IDENTIFIED BY 123;
GRANT CONNECT TO TRUONGBOMON;
GRANT SELECT ON ADMIN_OLS.PROJECT_OLS_THONGBAO TO TRUONGBOMON;

CREATE USER GIANGVIEN IDENTIFIED BY 123;
GRANT CONNECT TO GIANGVIEN;
GRANT SELECT ON ADMIN_OLS.PROJECT_OLS_THONGBAO TO GIANGVIEN;


BEGIN
    SA_USER_ADMIN.SET_USER_LABELS('AGENCY_POLICY','GIAOVU','GVU');
    SA_USER_ADMIN.SET_USER_LABELS('AGENCY_POLICY','GIANGVIEN','GV:CNPM:CS2');
    SA_USER_ADMIN.SET_USER_LABELS('AGENCY_POLICY','TRUONGBOMON','TDV:HTTT,CNPM,KHMT,CNTT,TGMT,MMT:CS2');
    SA_USER_ADMIN.SET_USER_LABELS('AGENCY_POLICY','TRUONGKHOA','TK:HTTT,CNPM,KHMT,CNTT,TGMT,MMT:CS1,CS2');
END;

SELECT * FROM DBA_SA_LEVELS; 
SELECT * FROM DBA_SA_COMPARTMENTS;
SELECT * FROM DBA_SA_GROUPS;
select* from all_sa_labels;
SELECT*FROM ADMIN_OLS.PROJECT_OLS_THONGBAO;
--============================================================================================================

SELECT * FROM PROJECT_NHANSU;
CREATE OR REPLACE PROCEDURE P_CREATE_USER
AS
    STRSQL VARCHAR2(2000);
    USERNAME VARCHAR2(100);
BEGIN 
    USERNAME := 'PROJECT_U_5';
    STRSQL := 'CREATE USER '||USERNAME||' IDENTIFIED BY 123';
    EXECUTE IMMEDIATE STRSQL;
    STRSQL := 'GRANT CONNECT TO '||USERNAME;
    EXECUTE IMMEDIATE STRSQL;
    STRSQL := 'GRANT P_TRUONGKHOA TO '||USERNAME;
    EXECUTE IMMEDIATE STRSQL;
    SA_USER_ADMIN.SET_USER_LABELS('AGENCY_POLICY',USERNAME,'TK:HTTT,CNPM,KHMT,CNTT,TGMT,MMT:CS1,CS2');
END;
/

DROP USER PROJECT_U_5 CASCADE;
EXEC P_CREATE_USER;

SELECT * FROM DBA_SYS_PRIVS WHERE GRANTEE = 'ADMIN_OLS';
SELECT * FROM DBA_SYS_PRIVS WHERE GRANTEE = 'SYS';

SELECT * FROM PROJECT_dangky;
--DELETE FROM PROJECT_dangky;

SELECT * FROM ROLE_TAB_PRIVS WHERE ROLE LIKE 'P%';
SELECT * FROM ADMIN_OLS.PROJECT_NVCOBAN_XEMTHONGTINCANHAN;
SELECT * FROM ADMIN_OLS.PROJECT_KHMO;
SELECT * FROM ADMIN_OLS.PROJECT_GIANGVIEN_XEMDANGKYDCPC;

EXEC ADMIN_OLS.PROJECT_GIANGVIEN_UPDATEDIEM('45', '2', 'NMLT', 2, 2024, 'CTTT', 5,6,7 )

SELECT * FROM ADMIN_OLS.PROJECT_SINHVIEN;

SELECT KHM1.MAHP FROM ADMIN_OLS.PROJECT_KHMO KHM1 WHERE KHM1.MACT = (SELECT SV.MACT FROM ADMIN_OLS.PROJECT_SINHVIEN SV WHERE SV.MASV = SUBSTR(SYS_CONTEXT('USERENV','SESSION_USER'),3)  )


SELECT SV_SELECT_HOCPHAN_FUNCTION('ADMIN_OLS', 'PROJECT_KHMO') FROM DUAL;

DELETE ADMIN_OLS.PROJECT_DANGKY
WHERE HK = 2 

INSERT INTO ADMIN_OLS.PROJECT_DANGKY
VALUES (1, '46', 'TKPM', 3, 2024,'CTTT',NULL, NULL, NULL, NULL);
    
INSERT INTO ADMIN_OLS.PROJECT_DANGKY
VALUES (1, '68', 'CHCSTT', 1, 2024,'VP',NULL, NULL, NULL, NULL);
UPDATE ADMIN_OLS.PROJECT_SINHVIEN
SET HOTEN = N'LÝ TỰ TRỌNG 1'
WHERE MASV = 1


DROP USER SV1 CASCADE;
CREATE USER SV1 IDENTIFIED BY 123;
GRANT CONNECT TO SV1;
GRANT P_SINHVIEN TO SV1;

SELECT granted_role FROM user_role_privs ORDER BY granted_role DESC;
SELECT * FROM ADMIN_OLS.project_khmo kh inner join ADMIN_OLS.project_hocphan hp on kh.mahp = hp.mahp;
SELECT * FROM ADMIN_OLS.PROJECT_NHANSU;
select * from project_PHANCONG;
select * from project_phancong pc join project_nhansu ns on ns.manv = pc.magv;


GRANT P_TRUONGKHOA TO PROJECT_U_1;
revoke P_TRUONGKHOA FROM PROJECT_U_1;
SELECT granted_role FROM user_role_privs ;


SELECT * FROM USER_TAB_PRIVS WHERE GRANTEE LIKE 'PROJECT_U_%' AND PRIVILEGE = 'SELECT' AND TABLE_NAME NOT LIKE 'PROJECT_U_%' AND TABLE_NAME LIKE '%NHANVIEN';

SELECT * FROM ROLE_TAB_PRIVS WHERE (TABLE_NAME LIKE '%_NVCOBAN_%' OR TABLE_NAME LIKE '%_NHANSU%') AND PRIVILEGE = 'SELECT';

SELECT * FROM admin_ols.PROJECT_SINHVIEN;

SELECT username FROM all_users WHERE username LIKE 'SV%' order by username ;

--XÓA TOÀN BỘ USER NHÂN VIÊN
BEGIN
   FOR u IN (SELECT username FROM all_users WHERE username LIKE 'PROJECT_U%') LOOP
      EXECUTE IMMEDIATE 'DROP USER ' || u.username || ' CASCADE';
   END LOOP;
END;
/
--XÓA TOÀN BỘ USER SINH VIÊN
BEGIN
   FOR u IN (SELECT username FROM all_users WHERE username LIKE 'SV%') LOOP
      EXECUTE IMMEDIATE 'DROP USER ' || u.username || ' CASCADE';
   END LOOP;
END;
/
CREATE OR REPLACE PROCEDURE PROJECT_CREATE_NHANVIEN
AS
 CURSOR CUR IS (SELECT USERNAME, VAITRO, MADV, MANV
 FROM PROJECT_NHANSU
 WHERE USERNAME NOT IN (SELECT USERNAME
 FROM ALL_USERS)
 );
 
  TYPE rec_type IS RECORD (
   USR VARCHAR2(100),
   VAITRO VARCHAR2(100), 
   MADV VARCHAR(100), 
   MANV VARCHAR(10)
 );
 STRSQL VARCHAR(2000);
 rec rec_type;
 
BEGIN
 OPEN CUR;
 LOOP
 FETCH CUR INTO rec;
 EXIT WHEN CUR%NOTFOUND;

 STRSQL := 'CREATE USER '||rec.USR||' IDENTIFIED BY '||123;
 EXECUTE IMMEDIATE(STRSQL);
 
 STRSQL := 'GRANT CONNECT TO '||rec.USR;
 EXECUTE IMMEDIATE(STRSQL);
 
 STRSQL := 'GRANT ' || rec.VAITRO || ' TO '||rec.USR;
 EXECUTE IMMEDIATE(STRSQL);
 
 IF rec.VAITRO = 'P_TRUONGKHOA' THEN
    SA_USER_ADMIN.SET_USER_LABELS('AGENCY_POLICY',rec.USR,'TK:HTTT,CNPM,KHMT,CNTT,TGMT,MMT:CS1,CS2');
 ELSIF rec.VAITRO = 'P_TRUONGDONVI' THEN
    IF rec.MANV = 1 THEN
        SA_USER_ADMIN.SET_USER_LABELS('AGENCY_POLICY',rec.USR,'TDV:' || rec.MADV ||  ':CS1');
    ELSE 
        SA_USER_ADMIN.SET_USER_LABELS('AGENCY_POLICY',rec.USR,'TDV:HTTT,CNPM,KHMT,CNTT,TGMT,MMT:CS2');
    END IF;
 ELSIF rec.VAITRO = 'P_GIAOVU' THEN
    SA_USER_ADMIN.SET_USER_LABELS('AGENCY_POLICY',rec.USR,'GVU:');
 ELSIF rec.VAITRO = 'P_GIANGVIEN' THEN
    IF rec.MANV = 1 THEN
        SA_USER_ADMIN.SET_USER_LABELS('AGENCY_POLICY',rec.USR,'GV:' || rec.MADV ||  ':CS1');
    ELSE 
        SA_USER_ADMIN.SET_USER_LABELS('AGENCY_POLICY',rec.USR,'GV:'|| rec.MADV ||':CS2');
    END IF;
 ELSIF rec.VAITRO = 'P_NVCOBAN' THEN
    SA_USER_ADMIN.SET_USER_LABELS('AGENCY_POLICY',rec.USR,'NV:');
 END IF;

 END LOOP;
 CLOSE CUR;
END; 
/

CREATE OR REPLACE PROCEDURE PROJECT_CREATE_SINHVIEN
AS
 CURSOR CUR IS (SELECT MASV
 FROM PROJECT_SINHVIEN
 WHERE 'SV'|| MASV NOT IN (SELECT USERNAME
 FROM ALL_USERS)
 );
 USR VARCHAR(100);
 STRSQL VARCHAR(2000);
BEGIN
 OPEN CUR;
 LOOP
 FETCH CUR INTO USR;
 EXIT WHEN CUR%NOTFOUND;

 STRSQL := 'CREATE USER '|| 'SV' || USR ||' IDENTIFIED BY '||123;
 EXECUTE IMMEDIATE(STRSQL);
 STRSQL := 'GRANT CONNECT TO '||'SV' || USR;
 EXECUTE IMMEDIATE(STRSQL);
 STRSQL := 'GRANT ' || 'P_SINHVIEN' || ' TO '|| 'SV' || USR;
 EXECUTE IMMEDIATE(STRSQL);
 SA_USER_ADMIN.SET_USER_LABELS('AGENCY_POLICY', 'SV'||USR,'SV:HTTT,CNPM,KHMT,CNTT,TGMT,MMT:CS1,CS2');
 END LOOP;
 CLOSE CUR;
END; 

EXEC PROJECT_CREATE_NHANVIEN;
EXEC PROJECT_CREATE_SINHVIEN;

SELECT * FROM ROLE_TAB_PRIVS WHERE  TABLE_NAME LIKE '%_DONVI%' AND PRIVILEGE = 'UPDATE'



SELECT * FROM ROLE_TAB_PRIVS WHERE TABLE_NAME LIKE '%_KHMO%' AND TABLE_NAME NOT LIKE '%TRUONGDONVI%'  AND PRIVILEGE = 'SELECT'

SELECT * FROM ADMIN_OLS.PROJECT_V1_TRUONGDONVI_PHANCONG UNION 
SELECT * FROM ADMIN_OLS.PROJECT_V2_TRUONGDONVI_PHANCONG 


