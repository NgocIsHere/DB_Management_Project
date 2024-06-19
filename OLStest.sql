SELECT VALUE FROM v$option WHERE parameter = 'Oracle Label Security'; 
SELECT status FROM dba_ols_status WHERE name = 'OLS_CONFIGURE_STATUS'; 

--EXEC LBACSYS.CONFIGURE_OLS; -- This procedure registers Oracle Label Security.
--EXEC LBACSYS.OLS_ENFORCEMENT.ENABLE_OLS; -- This procedure enables it 

BEGIN
   LBACSYS.CONFIGURE_OLS; -- This procedure registers Oracle Label Security.
END;
/
BEGIN
   LBACSYS.OLS_ENFORCEMENT.ENABLE_OLS; -- This procedure enables Oracle Label Security.
END;
/

SHUTDOWN IMMEDIATE;
STARTUP;

select * from v$services; 

ALTER USER lbacsys IDENTIFIED BY lbacsys ACCOUNT UNLOCK; 
--==============================B1: CHẠY 3 DÒNG NÀY NẾU ĐÃ TỪNG CHẠY OLS RỒI=======================
ALTER PLUGGABLE DATABASE PROJECT_DBMANAGEMENT OPEN READ WRITE;

ALTER SESSION SET CONTAINER = PROJECT_DBMANAGEMENT;
SHOW CON_NAME;

--==========================================================================
ALTER SESSION SET CONTAINER = CDB$ROOT;

CREATE USER ADMIN_OLS IDENTIFIED BY 123 CONTAINER = CURRENT;
GRANT CONNECT,RESOURCE TO ADMIN_OLS; --CẤP QUYỀN CONNECT VÀ RESOURCE
GRANT UNLIMITED TABLESPACE TO ADMIN_OLS; --CẤP QUOTA CHO ADMIN_OLS
GRANT SELECT ANY DICTIONARY TO ADMIN_OLS; --CẤP QUYỀN ĐỌC DICTIONARY

GRANT EXECUTE ON LBACSYS.SA_COMPONENTS TO ADMIN_OLS WITH GRANT OPTION;
GRANT EXECUTE ON LBACSYS.sa_user_admin TO ADMIN_OLS WITH GRANT OPTION;
GRANT EXECUTE ON LBACSYS.sa_label_admin TO ADMIN_OLS WITH GRANT OPTION;
GRANT EXECUTE ON sa_policy_admin TO ADMIN_OLS WITH GRANT OPTION;
GRANT EXECUTE ON char_to_label TO ADMIN_OLS WITH GRANT OPTION; 

GRANT LBAC_DBA TO ADMIN_OLS;
GRANT EXECUTE ON sa_sysdba TO ADMIN_OLS;
GRANT EXECUTE ON TO_LBAC_DATA_LABEL TO ADMIN_OLS; -- CẤP QUYỀN THỰC THI 
GRANT EXECUTE ON LBACSYS.CONFIGURE_OLS TO ADMIN_OLS;
GRANT EXECUTE ON LBACSYS.OLS_ENFORCEMENT TO ADMIN_OLS;

GRANT SYSDBA TO ADMIN_OLS;
GRANT SYSBACKUP TO ADMIN_OLS;
GRANT CONNECT TO ADMIN_OLS WITH ADMIN OPTION;
GRANT EXECUTE ANY PROCEDURE TO ADMIN_OLS;
GRANT CREATE USER TO ADMIN_OLS;

ALTER PLUGGABLE DATABASE PROJECT_DBMANAGEMENT ENABLE UNIFIED_AUDIT;


SELECT *
FROM cdb_services


INSERT INTO admin_ols.project_dangky VALUES (1, 77, 'KTDLUD', 3, 2024, 'CTTT', NULL,NULL,NULL,NULL)

select * from admin_ols.project_dangky;

DELETE FROM admin_ols.project_dangky WHERE MAGV = 77 AND MAHP = 'KTDLUD' AND HK = 3 AND NAM = 2024 AND MACT = 'CTTT' 

select * from admin_ols.project_sinhvien;

delete from admin_ols.project_sinhvien where masv = 4

