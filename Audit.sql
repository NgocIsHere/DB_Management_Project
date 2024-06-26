-- Yêu cầu 1: Kích hoạt việc ghi nhật ký hệ thống

--Để kích hoạt ghi nhật ký hệ thống trong Oracle, cần đặt tham số khởi tạo AUDIT_TRAIL. Có ba tùy chọn để lưu trữ các bản ghi kiểm toán:
-- 1. OS: Lưu trữ các bản ghi kiểm toán trong các tệp hệ điều hành.
-- 2. DB: Lưu trữ các bản ghi kiểm toán trong cơ sở dữ liệu (bảng SYS.AUD$).
-- 3. DB_EXTENDED: Lưu trữ các bản ghi kiểm toán trong cơ sở dữ liệu với thông tin bổ sung (ví dụ: văn bản SQL).

-- Bật kiểm toán và lưu trữ các bản ghi trong cơ sở dữ liệu
--ALTER SYSTEM SET audit_trail = DB SCOPE = SPFILE;


-- Yêu cầu 2: Thực hiện ghi nhật ký hệ thống dùng Standard audit
AUDIT SELECT, INSERT, UPDATE, DELETE ON  ADMIN_OLS.PROJECT_NHANSU BY ACCESS WHENEVER SUCCESSFUL;
AUDIT SELECT, INSERT, UPDATE, DELETE ON  ADMIN_OLS.PROJECT_NHANSU BY ACCESS WHENEVER NOT SUCCESSFUL;

AUDIT SELECT, INSERT, UPDATE, DELETE ON  ADMIN_OLS.PROJECT_NVCOBAN_XEMTHONGTINCANHAN BY ACCESS WHENEVER NOT SUCCESSFUL;
AUDIT SELECT, INSERT, UPDATE, DELETE ON  ADMIN_OLS.PROJECT_NVCOBAN_XEMTHONGTINCANHAN BY ACCESS WHENEVER  SUCCESSFUL;

AUDIT EXECUTE ON ADMIN_OLS.PROJECT_GIANGVIEN_UPDATEDIEM BY ACCESS WHENEVER NOT SUCCESSFUL;
AUDIT EXECUTE ON ADMIN_OLS.PROJECT_GIANGVIEN_UPDATEDIEM BY ACCESS WHENEVER SUCCESSFUL;

AUDIT EXECUTE ON ADMIN_OLS.SV_INSERT_DELETE_DANGKY_FUNCTION BY ACCESS WHENEVER SUCCESSFUL;
AUDIT EXECUTE ON ADMIN_OLS.SV_INSERT_DELETE_DANGKY_FUNCTION BY ACCESS WHENEVER NOT SUCCESSFUL;

--
--SELECT * FROM ADMIN_OLS.PROJECT_NHANSU;
--SELECT * FROM ADMIN_OLS.PROJECT_NVCOBAN_XEMTHONGTINCANHAN;
--
--SELECT * FROM ADMIN_OLS.PROJECT_DANGKY;
--
--CREATE USER PROJECT_U_1000 IDENTIFIED BY 123;
--GRANT CONNECT TO PROJECT_U_1000;
--
--GRANT SELECT, UPDATE ON ADMIN_OLS.PROJECT_DANGKY TO PROJECT_U_1000;



--UPDATE ADMIN_OLS.PROJECT_DANGKY
--SET DIEMQT  = 10, 
--    DIEMCK = 10, 
--    DIEMTK = 9.6* DIEMTH + 0.3 * DIEMCK + 0.1*DIEMQT
--WHERE MASV = 2 AND MAGV = 38 AND MAHP = 'PTG' AND HK = 1 AND NAM = 2024 AND MACT = 'CQ';


---- Theo dõi hành vi của người dùng cụ thể trên một bảng:
--AUDIT SELECT, INSERT, UPDATE, DELETE ON <schema>.<table_name> BY <user_name>;
--
---- Theo dõi hành vi của người dùng cụ thể trên một view:
--AUDIT SELECT, INSERT, UPDATE, DELETE ON <schema>.<view_name> BY <user_name>;
--
---- Theo dõi hành vi của người dùng cụ thể trên một thủ tục được lưu trữ:
--AUDIT EXECUTE ON <schema>.<procedure_name> BY <user_name>;
--
---- Theo dõi hành vi của người dùng cụ thể trên một function:
--AUDIT EXECUTE ON <schema>.<function_name> BY <user_name>;
--
---- Theo dõi các hành vi thành công trên một bảng:
--AUDIT SELECT, INSERT, UPDATE, DELETE ON <schema>.<table_name> BY ACCESS WHENEVER SUCCESSFUL;
--
---- Theo dõi các hành vi không thành công trên một bảng:
--AUDIT SELECT, INSERT, UPDATE, DELETE ON <schema>.<table_name> BY ACCESS WHENEVER NOT SUCCESSFUL;


-- Yêu cầu 3: Thực hiện Fine-grained Audit

-- Hành vi Cập nhật quan hệ ĐANGKY tại các trường liên quan đến điểm số nhưng người đó không thuộc vai trò Giảng viên:
BEGIN
  DBMS_FGA.DROP_POLICY(
    object_schema => 'ADMIN_OLS',
    object_name => 'PROJECT_DANGKY',
    policy_name => 'DIEM_UPDATE_POLICY'
  );
END;
/
BEGIN
  DBMS_FGA.DROP_POLICY(
    object_schema => 'ADMIN_OLS',
    object_name => 'PROJECT_NHANSU',
    policy_name => 'PHUCAP_ACCESS_POLICY'
  );
END;
/

--GRANT SELECT ON DUAL TO PROJECT_U_1000;
--GRANT EXECUTE ON ADMIN_OLS.is_role_set TO PROJECT_U_1000;
--
--SELECT ADMIN_OLS.is_role_set('P_GIANGVIEN') FROM DUAL;


  

CREATE OR REPLACE FUNCTION is_role_set(p_role IN VARCHAR2) RETURN INTEGER AS
  v_role_count INTEGER;
BEGIN
  SELECT COUNT(*)
  INTO v_role_count
  FROM DBA_ROLE_PRIVS
  WHERE GRANTEE = SYS_CONTEXT('USERENV', 'SESSION_USER')
  AND GRANTED_ROLE = p_role;

  IF v_role_count > 0 THEN
    RETURN 1; -- Role is granted to the user
  ELSE
    RETURN 0; -- Role is not granted to the user
  END IF;
END;
/

--SELECT* FROM ADMIN_OLS.PROJECT_GIANGVIEN_XEMDANGKYDCPC

--SELECT DBMS_SESSION.IS_ROLE_ENABLED('P_GIANGVIEN') AS ROLE_ENABLED FROM DUAL;
--
--SELECT * FROM DBA_ROLE_PRIVS WHERE GRANTED_ROLE = 'P_GIANGVIEN'
--SELECT GRANTEE FROM DBA_ROLE_PRIVS WHERE GRANTED_ROLE = 'P_GIANGVIEN' OR GRANTED_ROLE = 'P_TRUONGKHOA' OR GRANTED_ROLE = 'P_TRUONGDONVI' 
--
--SELECT * 
--        FROM DBA_TAB_PRIVS 
--        WHERE GRANTEE IN (
--          SELECT GRANTED_ROLE 
--          FROM DBA_ROLE_PRIVS 
--          CONNECT BY PRIOR GRANTED_ROLE = GRANTEE
--          START WITH GRANTED_ROLE = 'P_GIANGVIEN'
--        );
--
--
--GRANT SELECT ON DUAL TO project_u_20
--GRANT EXECUTE ON is_role_set TO project_u_20
--SELECT ADMIN_OLS.is_role_set('P_GIANGVIEN') FROM DUAL;

BEGIN
  DBMS_FGA.ADD_POLICY(
    object_schema => 'ADMIN_OLS',
    object_name => 'PROJECT_DANGKY',
    policy_name => 'DIEM_UPDATE_POLICY',
    audit_condition => 'is_role_set(''P_GIANGVIEN'') = 0',
    audit_column => 'DIEMTH, DIEMQT, DIEMCK, DIEMTK',
    statement_types => 'UPDATE'
  );
END;
/



-- Hành vi của người dùng này có thể đọc trên trường PHUCAP của người khác ở quan hệ NHANSU:
BEGIN
  DBMS_FGA.ADD_POLICY(
    object_schema => 'ADMIN_OLS',
    object_name => 'PROJECT_NHANSU',
    policy_name => 'PHUCAP_ACCESS_POLICY',
    audit_condition => ' ''PROJECT_U_''||MANV != SYS_CONTEXT(''USERENV'', ''SESSION_USER'')',
    audit_column => 'PHUCAP',
    statement_types => 'SELECT'
  );
END;
/
--SELECT * FROM USER_TAB_PRIVS WHERE PRIVILEGE = 'UPDATE' AND TABLE_NAME LIKE '%DANGKY%';

-- Yêu cầu 4: Kiểm tra (đọc xuất) dữ liệu nhật ký hệ thống

-- DBA_AUDIT_TRAIL: Chế độ xem này hiển thị tất cả các bản ghi kiểm toán tiêu chuẩn được tạo bởi Oracle. 
-- Nó chứa thông tin chi tiết về các hoạt động như câu lệnh DDL (Data Definition Language) đã thực thi, 
-- các hoạt động cấp đặc quyền hệ thống và các hoạt động đăng nhập/đăng xuất.

  SELECT USERNAME, OBJ_NAME, ACTION_NAME, RETURNCODE, TIMESTAMP 
  FROM DBA_AUDIT_TRAIL 
  WHERE USERNAME != 'ADMIN_OLS' 
  ORDER BY TIMESTAMP DESC;



-- DBA_COMMON_AUDIT_TRAIL: Chế độ xem này kết hợp các bản ghi kiểm toán tiêu chuẩn và chi tiết. 
-- Nó cung cấp chế độ xem hợp nhất của tất cả các hoạt động kiểm toán, giúp dễ dàng phân tích và báo cáo.
--SELECT * FROM DBA_COMMON_AUDIT_TRAIL;

-- DBA_FGA_AUDIT_TRAIL: Chế độ xem này đặc biệt hiển thị các bản ghi kiểm toán chi tiết (FGA) được tạo bởi Oracle. 
-- Nó chứa thông tin về các sự kiện FGA, chẳng hạn như truy vấn các cột cụ thể hoặc truy cập dữ liệu dựa trên các điều kiện nhất định.

SELECT TIMESTAMP, DB_USER, OBJECT_NAME, POLICY_NAME, SQL_TEXT FROM DBA_FGA_AUDIT_TRAIL ORDER BY TIMESTAMP DESC ;
--
SELECT * FROM DBA_FGA_AUDIT_TRAIL ORDER BY TIMESTAMP DESC ;


-- This SQL statement deletes records from the aud$ table where the TIMESTAMP is older than 30 days from the current date.
DELETE FROM admin_ols.aud$ WHERE TIMESTAMP <= SYSDATE - 30;
select * from aud$;
--BEGIN
--DBMS_SCHEDULER.create_job (
--job_name => 'JOB_PURGE_AUDIT_RECORDS',
--job_type => 'PLSQL_BLOCK',
--job_action => 'BEGIN DBMS_AUDIT_MGMT.SET_LAST_ARCHIVE_TIMESTAMP(DBMS_AUDIT_MGMT.AUDIT_TRAIL_AUD_STD, TRUNC(SYSTIMESTAMP)-30); END;',
--start_date => SYSTIMESTAMP,
--repeat_interval => 'freq=daily; byhour=0; byminute=0; bysecond=0;',
--end_date => NULL,
--enabled => TRUE,
--comments => 'Update last_archive_timestamp');
--END;
--/
SELECT* FROM ADMIN_OLS.PROJECT_GIANGVIEN_XEMDANGKYDCPC;

UPDATE ADMIN_OLS.PROJECT_GIANGVIEN_XEMDANGKYDCPC SET DIEMTH = 1 , DIEMQT = 1 , DIEMCK = 1 , DIEMTK = 0.6*1 + 0.1*1 + 0.3*1 WHERE MASV = 25 AND MAGV = 28 AND MAHP = 'HTTTDN' AND HK = 1 AND MACT = 'VP' 