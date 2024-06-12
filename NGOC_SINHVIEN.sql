ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE
BEGIN
    DBMS_RLS.DROP_POLICY(
        OBJECT_SCHEMA =>'C##ADMIN',
        OBJECT_NAME=>'project_DANGKY',
        POLICY_NAME =>'SV_DANGKY_SELECT'
    );
END;
/
-- CS6:
-- Trên quan hệ SINHVIEN, sinh viên chỉ được xem thông tin của chính mình, được
-- Chỉnh sửa thông tin địa chỉ (ĐCHI) và số điện thoại liên lạc (ĐT) của chính sinh viên.
CREATE OR REPLACE FUNCTION SV_SELECT_FUNCTION (
    P_SCHEMA VARCHAR2,
    P_OBJ VARCHAR2
)
RETURN VARCHAR2
AS
    L_USER VARCHAR2(100); -- Changed USER to L_USER to avoid conflicts
    MASV VARCHAR2(100); -- Corrected the declaration
BEGIN
    L_USER := SYS_CONTEXT('USERENV','SESSION_USER'); -- Corrected the typo in USERENV
    MASV := REPLACE(L_USER, 'SV', ''); -- Corrected the typo in variable name
    RETURN 'MASV = ''' || MASV || '''';
END;
/
BEGIN
    DBMS_RLS.ADD_POLICY(
        OBJECT_SCHEMA =>'C##ADMIN',
        OBJECT_NAME=>'project_sinhvien',
        POLICY_NAME =>'SV_SELECT_SINHVIEN',
        POLICY_FUNCTION=>'SV_SELECT_FUNCTION',
        STATEMENT_TYPES=>'SELECT, UPDATE',
        UPDATE_CHECK => TRUE
);
END;
/
grant SELECT ON PROJECT_SINHVIEN TO C##P_SINHVIEN;
grant UPDATE (DCHI,DT) ON PROJECT_SINHVIEN TO C##P_SINHVIEN;
-- Xem danh sách tất cả học phần (HOCPHAN), kế hoạch mở môn (KHMO) của chương
-- trình đào tạo mà sinh viên đang theo học.
CREATE OR REPLACE FUNCTION SV_SELECT_KHMO_FUNCTION
  (P_SCHEMA VARCHAR2, P_OBJ VARCHAR2)
RETURN VARCHAR2
AS
  MA VARCHAR(5);
  STRSQL VARCHAR2(2000);
  CURSOR CUR IS (
    SELECT MACT
    FROM PROJECT_SINHVIEN
    WHERE MASV = REPLACE(SYS_CONTEXT('USERENV','SESSION_USER'), 'SV', ''));
BEGIN
  STRSQL := ''; 
  OPEN CUR;
  LOOP
    FETCH CUR INTO MA;
    EXIT WHEN CUR%NOTFOUND;
    IF (STRSQL IS NOT NULL) THEN
      STRSQL := STRSQL || ',''' || MA || ''''; -- Corrected concatenation operator
    ELSE
      STRSQL := '''' || MA || ''''; -- Corrected concatenation operator
    END IF;
  END LOOP;
  RETURN 'MACT IN (' || STRSQL || ')';
END;
/
BEGIN
  DBMS_RLS.ADD_POLICY(
    OBJECT_SCHEMA =>'C##ADMIN',
    OBJECT_NAME=>'PROJECT_KHMO', -- Corrected table name to uppercase
    POLICY_NAME =>'SV_SELECT_KHMO',
    POLICY_FUNCTION=>'SV_SELECT_KHMO_FUNCTION',
    STATEMENT_TYPES=>'SELECT',
    UPDATE_CHECK => TRUE
  );
END;
/

CREATE OR REPLACE FUNCTION SV_SELECT_HOCPHAN_FUNCTION
 (P_SCHEMA VARCHAR2, P_OBJ VARCHAR2)
RETURN VARCHAR2
AS
 MA VARCHAR2(5);
 STRSQL VARCHAR2(2000);
 CURSOR CUR IS (SELECT MAHP
 FROM PROJECT_KHMO);
BEGIN
 OPEN CUR;
 LOOP
 FETCH CUR INTO MA;
 EXIT WHEN CUR%NOTFOUND;
 IF (STRSQL IS NOT NULL) THEN
 STRSQL := STRSQL ||''',''';
 END IF;
 STRSQL := STRSQL || MA;
 END LOOP;
 RETURN 'MAHP IN ('''||STRSQL||''')';
END; 
/
BEGIN
  DBMS_RLS.ADD_POLICY(
    OBJECT_SCHEMA =>'C##ADMIN',
    OBJECT_NAME=>'project_HOCPHAN',
    POLICY_NAME =>'SV_SELECT_HOCPHAN',
    POLICY_FUNCTION=>'SV_SELECT_HOCPHAN_FUNCTION',
    STATEMENT_TYPES=>'SELECT'
  );
END;
/
-- Thêm, Xóa các dòng dữ liệu đăng ký học phần (ĐANGKY) liên quan đến chính sinh
--viên đó trong học kỳ của năm học hiện tại (nếu thời điểm hiệu chỉnh đăng ký còn hợp
--lệ).
CREATE OR REPLACE FUNCTION SV_INSERT_DELETE_DANGKY_FUNCTION (
    P_SCHEMA VARCHAR2,
    P_OBJ VARCHAR2
)
RETURN VARCHAR2
AS
    v_limit_date DATE;
    v_masv VARCHAR2(50);
    v_hk int;
    v_year int;
    v_month VARCHAR2(50);
BEGIN
    -- Set the end of the valid registration period
    SELECT EXTRACT(YEAR FROM SYSDATE) into v_year FROM DUAL;
    SELECT MAX(HK) into v_hk FROM C##ADMIN.PROJECT_KHMO WHERE NAM = v_year ;
    IF v_hk = 1 THEN
        v_month := '09';
    ELSIF v_hk = 2 THEN
        v_month := '02';
    ELSIF v_hk = 3 THEN
        v_month := '07';
    END IF;
    v_limit_date := TO_DATE(v_year || '/' || v_month || '/19', 'yyyy/mm/dd');
    
    -- Get the student ID from the current session user
    v_masv := REPLACE(SYS_CONTEXT('USERENV', 'SESSION_USER'), 'SV', '');
    
    -- Check if the current date is within the valid registration period
    IF CURRENT_DATE <= v_limit_date THEN
        -- Allow operations for the current student in the current academic year and semester
        RETURN 'MASV = ''' || v_masv || '''';
    ELSE
        -- Disallow operations
        RETURN '1=0';
    END IF;
END;
/
BEGIN
    DBMS_RLS.ADD_POLICY(
        OBJECT_SCHEMA =>'C##ADMIN',
        OBJECT_NAME=>'PROJECT_DANGKY',
        POLICY_NAME =>'SV_DANGKY_INSERT',
        POLICY_FUNCTION=>'SV_INSERT_DELETE_DANGKY_FUNCTION',
        STATEMENT_TYPES=> 'INSERT'
    );
END;
/
BEGIN
    DBMS_RLS.ADD_POLICY(
        OBJECT_SCHEMA    => 'C##ADMIN',
        OBJECT_NAME      => 'PROJECT_DANGKY',
        POLICY_NAME      => 'SV_DANGKY_DELETE',
        FUNCTION_SCHEMA  => 'C##ADMIN', -- Schema where the function is located
        POLICY_FUNCTION  => 'SV_INSERT_DELETE_DANGKY_FUNCTION',
        STATEMENT_TYPES  => 'DELETE'
    );
END;
/
-- Sinh viên không được chỉnh sửa trên các trường liên quan đến điểm.
CREATE OR REPLACE FUNCTION SV_UPDATE_DIEM_FUNCTION (
    P_SCHEMA VARCHAR2,
    P_OBJ VARCHAR2
)
RETURN VARCHAR2
AS
BEGIN
    -- This policy will always be FALSE for UPDATE operations on grade-related fields
    RETURN '1=0'; -- Prevent all updates
END;
/
BEGIN
    DBMS_RLS.ADD_POLICY(
        OBJECT_SCHEMA    => 'C##ADMIN',
        OBJECT_NAME      => 'PROJECT_DANGKY',
        POLICY_NAME      => 'SV_UPDATE_DIEM',
        FUNCTION_SCHEMA  => 'C##ADMIN', -- Schema where the function is located
        POLICY_FUNCTION  => 'SV_UPDATE_DIEM_FUNCTION',
        STATEMENT_TYPES  => 'UPDATE',
        sec_relevant_cols    => 'DIEMTHI, DIEMQT, DIEMCK, DIEMTK' -- Columns to restrict
    );
END;
/
-- Sinh viên được Xem tất cả thông tin trên quan hệ ĐANGKY tại các dòng dữ liệu liên
-- quan đến chính sinh 
BEGIN
    DBMS_RLS.ADD_POLICY(
        OBJECT_SCHEMA =>'C##ADMIN',
        OBJECT_NAME=>'PROJECT_DANGKY',
        POLICY_NAME =>'SV_DANGKY_SELECT',
        POLICY_FUNCTION=>'SV_SELECT_FUNCTION',
        STATEMENT_TYPES=>'SELECT'
    );
END;
/
