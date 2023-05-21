import "./Login.styles.css";
import React, { useState } from 'react';
import { Button, Form, Input } from 'antd';
import { UserOutlined, LockOutlined } from '@ant-design/icons';

import { useNavigate } from 'react-router-dom';
import {useAuth} from "../../Auth/AuthContext";

import {loginUser, getUserRole} from "../../Requests/Requests";
import Cookies from "js-cookie";
import {toast} from "react-toastify";

const animation = require('../../assets/media/videos/gradebook.gif');

const Login: React.FC = () => {
    const [loading, setLoading] = useState(false);
    const navigate = useNavigate();
    const { setUserId, setUserRoleId } = useAuth();


    const onFinish = async (values: any) => {
        setLoading(true);
        console.log('Received values of form: ', values);
        let isAuthenticated = false;
        try {
            const data = await loginUser(values.username, values.password);
            if (data) {
                isAuthenticated = true;
                const userRole = await (getUserRole(data));
                console.log("UserID:" + data);
                console.log("RoleID:" + userRole);
                setUserId(data);
                setUserRoleId(userRole);
                Cookies.set("isUserLoggedIn", "true");
                Cookies.set("userId", data.toString());
                Cookies.set("userRoleId", userRole.toString());

            }
        } catch (error) {
            toast.error("Пароль та логін не співпадають, спробуйте ще раз");
        }

        if (isAuthenticated) {
            navigate('/main-menu');
        }
        setLoading(false);
    };

    return (
        <React.Fragment>
            <img style={{width:'400px', height:'400px'}} src={animation} alt="this slowpoke moves"  />
        <Form
            name="login"
            className="login-form"
            initialValues={{ remember: true }}
            onFinish={onFinish}
        >
            <div className="login-form-heading">Електронний журнал - Форма авторизації</div>
            <Form.Item
                name="username"
                rules={[{ required: true, message: 'Будь-ласка введіть логін!' }]}
            >
                <Input prefix={<UserOutlined className="site-form-item-icon" />} placeholder="Логін" />
            </Form.Item>
            <Form.Item
                name="password"
                rules={[{ required: true, message: 'Будь-ласка введіть пароль!' }]}
            >
                <Input
                    prefix={<LockOutlined className="site-form-item-icon" />}
                    type="password"
                    placeholder="Пароль"
                />
            </Form.Item>

            <Form.Item>
                <Button type="primary" htmlType="submit" className="login-form-button" loading={loading}>
                    Авторизуватись
                </Button>
            </Form.Item>
        </Form>
        </React.Fragment>
    );
};

export default Login;
