import "./Login.styles.css";
import React, { useState } from 'react';
import { Button, Form, Input } from 'antd';
import { UserOutlined, LockOutlined } from '@ant-design/icons';
import { useNavigate } from 'react-router-dom';

const Login: React.FC = () => {
    const [loading, setLoading] = useState(false);
    const navigate = useNavigate();

    const onFinish = (values: any) => {
        setLoading(true);
        console.log('Received values of form: ', values);
        // Add your login logic here

        const isAuthenticated = true; // Change this based on your authentication logic

        if (isAuthenticated) {
            navigate('/main-menu');
        }
        setLoading(false);
    };

    return (
        <Form
            name="login"
            className="login-form"
            initialValues={{ remember: true }}
            onFinish={onFinish}
        >
            <div className="login-form-heading">Online Grades Application - Login form</div>
            <Form.Item
                name="username"
                rules={[{ required: true, message: 'Please input your Username!' }]}
            >
                <Input prefix={<UserOutlined className="site-form-item-icon" />} placeholder="Username" />
            </Form.Item>
            <Form.Item
                name="password"
                rules={[{ required: true, message: 'Please input your Password!' }]}
            >
                <Input
                    prefix={<LockOutlined className="site-form-item-icon" />}
                    type="password"
                    placeholder="Password"
                />
            </Form.Item>

            <Form.Item>
                <Button type="primary" htmlType="submit" className="login-form-button" loading={loading}>
                    Log in
                </Button>
            </Form.Item>
        </Form>
    );
};

export default Login;
