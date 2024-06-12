-- Yêu cầu 1: Kích hoạt việc ghi nhật ký hệ thống

--Để kích hoạt ghi nhật ký hệ thống trong Oracle, cần đặt tham số khởi tạo AUDIT_TRAIL. Có ba tùy chọn để lưu trữ các bản ghi kiểm toán:
-- 1. OS: Lưu trữ các bản ghi kiểm toán trong các tệp hệ điều hành.
-- 2. DB: Lưu trữ các bản ghi kiểm toán trong cơ sở dữ liệu (bảng SYS.AUD$).
-- 3. DB_EXTENDED: Lưu trữ các bản ghi kiểm toán trong cơ sở dữ liệu với thông tin bổ sung (ví dụ: văn bản SQL).

-- Bật kiểm toán và lưu trữ các bản ghi trong cơ sở dữ liệu
ALTER SYSTEM SET audit_trail = DB SCOPE = SPFILE;


-- Yêu cầu 2: Thực hiện ghi nhật ký hệ thống dùng Standard audit

-- Theo dõi hành vi của người dùng cụ thể trên một bảng:
AUDIT SELECT, INSERT, UPDATE, DELETE ON <schema>.<table_name> BY <user_name>;

-- Theo dõi hành vi của người dùng cụ thể trên một view:
AUDIT SELECT, INSERT, UPDATE, DELETE ON <schema>.<view_name> BY <user_name>;

-- Theo dõi hành vi của người dùng cụ thể trên một thủ tục được lưu trữ:
AUDIT EXECUTE ON <schema>.<procedure_name> BY <user_name>;

-- Theo dõi hành vi của người dùng cụ thể trên một function:
AUDIT EXECUTE ON <schema>.<function_name> BY <user_name>;

-- Theo dõi các hành vi thành công trên một bảng:
AUDIT SELECT, INSERT, UPDATE, DELETE ON <schema>.<table_name> BY ACCESS WHENEVER SUCCESSFUL;

-- Theo dõi các hành vi không thành công trên một bảng:
AUDIT SELECT, INSERT, UPDATE, DELETE ON <schema>.<table_name> BY ACCESS WHENEVER NOT SUCCESSFUL;


-- Yêu cầu 3: Thực hiện Fine-grained Audit

-- Hành vi Cập nhật quan hệ ĐANGKY tại các trường liên quan đến điểm số nhưng người đó không thuộc vai trò Giảng viên:
BEGIN
  DBMS_FGA.ADD_POLICY(
    object_schema => 'PROJECT',
    object_name => 'DANGKY',
    policy_name => 'DIEM_UPDATE_POLICY',
    audit_condition => 'ORA_ROLE != ''C##P_GIANGVIEN''',
    audit_column => 'DIEMTHI, DIEMQT, DIEMCK, DIEMTK',
    statement_types => 'UPDATE'
  );
END;
/

-- Hành vi của người dùng này có thể đọc trên trường PHUCAP của người khác ở quan hệ NHANSU:
BEGIN
  DBMS_FGA.ADD_POLICY(
    object_schema => 'PROJECT',
    object_name => 'NHANSU',
    policy_name => 'PHUCAP_ACCESS_POLICY',
    audit_condition => 'MANV != SYS_CONTEXT(''USERENV'', ''SESSION_USER'')',
    audit_column => 'PHUCAP',
    statement_types => 'SELECT'
  );
END;
/


-- Yêu cầu 4: Kiểm tra (đọc xuất) dữ liệu nhật ký hệ thống

-- DBA_AUDIT_TRAIL: Chế độ xem này hiển thị tất cả các bản ghi kiểm toán tiêu chuẩn được tạo bởi Oracle. 
-- Nó chứa thông tin chi tiết về các hoạt động như câu lệnh DDL (Data Definition Language) đã thực thi, 
-- các hoạt động cấp đặc quyền hệ thống và các hoạt động đăng nhập/đăng xuất.
SELECT * FROM DBA_AUDIT_TRAIL; 

-- DBA_COMMON_AUDIT_TRAIL: Chế độ xem này kết hợp các bản ghi kiểm toán tiêu chuẩn và chi tiết. 
-- Nó cung cấp chế độ xem hợp nhất của tất cả các hoạt động kiểm toán, giúp dễ dàng phân tích và báo cáo.
SELECT * FROM DBA_COMMON_AUDIT_TRAIL;

-- DBA_FGA_AUDIT_TRAIL: Chế độ xem này đặc biệt hiển thị các bản ghi kiểm toán chi tiết (FGA) được tạo bởi Oracle. 
-- Nó chứa thông tin về các sự kiện FGA, chẳng hạn như truy vấn các cột cụ thể hoặc truy cập dữ liệu dựa trên các điều kiện nhất định.
SELECT * FROM DBA_FGA_AUDIT_TRAIL;