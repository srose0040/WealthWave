-- Check if the user already exists
SELECT user FROM mysql.user WHERE user = 'aa9c1a_bankapp';

-- Drop the existing user (if necessary)
DROP USER 'aa9c1a_bankapp'@'%';

-- Recreate the user
CREATE USER 'aa9c1a_bankapp'@'%' IDENTIFIED BY 'your_password_here';

-- Grant privileges to the user
GRANT ALL PRIVILEGES ON db_aa9c1a_bankapp.* TO 'aa9c1a_bankapp'@'%';

-- Flush privileges
FLUSH PRIVILEGES;
