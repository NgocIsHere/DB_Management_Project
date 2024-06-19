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

AUDIT EXECUTE ON SV_INSERT_DELETE_DANGKY_FUNCTION BY ACCESS WHENEVER SUCCESSFUL;
AUDIT EXECUTE ON SV_INSERT_DELETE_DANGKY_FUNCTION BY ACCESS WHENEVER NOT SUCCESSFUL;

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
--BEGIN
--  DBMS_FGA.DROP_POLICY(
--    object_schema => 'ADMIN_OLS',
--    object_name => 'PROJECT_DANGKY',
--    policy_name => 'DIEM_UPDATE_POLICY'
--  );
--END;
--/
--BEGIN
--  DBMS_FGA.DROP_POLICY(
--    object_schema => 'ADMIN_OLS',
--    object_name => 'PROJECT_NHANSU',
--    policy_name => 'PHUCAP_ACCESS_POLICY'
--  );
--END;
--/

--GRANT SELECT ON DUAL TO PROJECT_U_1000;
--GRANT EXECUTE ON ADMIN_OLS.is_role_set TO PROJECT_U_1000;
--
--SELECT ADMIN_OLS.is_role_set('P_GIANGVIEN') FROM DUAL;

CREATE OR REPLACE FUNCTION is_role_set(p_role IN VARCHAR2) RETURN INTEGER AS
BEGIN
  IF DBMS_SESSION.IS_ROLE_ENABLED(p_role) THEN
    RETURN 1;
  ELSE
    RETURN 0;
  END IF;
END;
/

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

--  SELECT USERNAME, OBJ_NAME, ACTION_NAME, RETURNCODE, TIMESTAMP 
--  FROM DBA_AUDIT_TRAIL 
--  WHERE USERNAME != 'ADMIN_OLS' 
--  ORDER BY TIMESTAMP DESC;

-- DBA_COMMON_AUDIT_TRAIL: Chế độ xem này kết hợp các bản ghi kiểm toán tiêu chuẩn và chi tiết. 
-- Nó cung cấp chế độ xem hợp nhất của tất cả các hoạt động kiểm toán, giúp dễ dàng phân tích và báo cáo.
--SELECT * FROM DBA_COMMON_AUDIT_TRAIL;

-- DBA_FGA_AUDIT_TRAIL: Chế độ xem này đặc biệt hiển thị các bản ghi kiểm toán chi tiết (FGA) được tạo bởi Oracle. 
-- Nó chứa thông tin về các sự kiện FGA, chẳng hạn như truy vấn các cột cụ thể hoặc truy cập dữ liệu dựa trên các điều kiện nhất định.
--SELECT TIMESTAMP, DB_USER, OBJECT_NAME, POLICY_NAME, SQL_TEXT FROM DBA_FGA_AUDIT_TRAIL ORDER BY TIMESTAMP DESC ;
--
--SELECT * FROM DBA_FGA_AUDIT_TRAIL ORDER BY TIMESTAMP DESC ;

