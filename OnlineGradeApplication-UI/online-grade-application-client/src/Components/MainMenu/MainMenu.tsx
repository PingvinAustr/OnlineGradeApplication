import React, {useEffect, useState} from 'react';
import './MainMenu.styles.css';
import {useAuth} from "../../Auth/AuthContext";
import {getUserDataById} from "../../Requests/Requests";
import { Layout, Menu } from 'antd';
import {BaseTSConstants} from "../../assets/constants/BaseTSConstants";
import { Dropdown, Menu as AntMenu } from 'antd';
import { DownOutlined } from '@ant-design/icons';
import { useNavigate } from 'react-router-dom';
import Disciplines from '../Disciplines/Disciplines';
const { Sider, Content } = Layout;



const userAvatar = require("../../assets/media/avatars/man1.png");

const MainMenu: React.FC = () => {
    const { userId, userRoleId, setUserId, setUserRoleId } = useAuth(); // Destructure setUserId and setUserRoleId
    const navigate = useNavigate(); // Add useNavigate hook

    const [userName, setUserName] = useState<string>('');
    const [selectedMenuItem, setSelectedMenuItem] = useState<string>('');


    const handleMenuClick = (e: any) => {
        setSelectedMenuItem(e.key);
    };

    const renderContent = () => {
        switch (selectedMenuItem) {
            case 'Disciplines':
                return <Disciplines />;
            // case '2':
            //     return <Groups />;
            default:
                return null;
        }
    };

    useEffect(() => {
        console.log('Current user ID:', userId);
        console.log('Current user role ID:', userRoleId);

        const fetchUserData = async () => {
            const currentUserData = await getUserDataById(userId);
            console.log(currentUserData);
            setUserName(currentUserData.firstName + ' ' + currentUserData.lastName);
        };

        if (userId) {
            fetchUserData();
        }

    }, [userId, userRoleId]);

    const renderMenuItems = () => {
        if (userRoleId === BaseTSConstants.StudentRoleId) {
            return (
                <>
                    <Menu.Item key="1">Оцінки</Menu.Item>
                    <Menu.Item key="2">Завдання</Menu.Item>
                    <Menu.Item key="Disciplines">Дисципліни</Menu.Item>
                    <Menu.Item key="4">Викладачі</Menu.Item>
                    <Menu.Item key="5">Список групи</Menu.Item>
                </>
            );
        } else if (userRoleId === BaseTSConstants.TeacherRoleId) {
            return (
                <>
                    <Menu.Item key="Disciplines">Дисципліни</Menu.Item>
                    <Menu.Item key="2">Студенти</Menu.Item>
                    <Menu.Item key="3">Групи</Menu.Item>
                    <Menu.Item key="4">Завдання</Menu.Item>
                    <Menu.Item key="5">Оцінки</Menu.Item>
                </>
            );
        }
        else if (userRoleId === BaseTSConstants.AdministrationPersonRoleId) {
            return (
                <>
                    <Menu.Item key="Disciplines">Дисципліни</Menu.Item>
                    <Menu.Item key="2">Студенти</Menu.Item>
                    <Menu.Item key="3">Групи</Menu.Item>
                    <Menu.Item key="4">Завдання</Menu.Item>
                    <Menu.Item key="5">Оцінки</Menu.Item>
                    <Menu.Item key="6">Користувачі системи</Menu.Item>
                </>
            );
        }
        else if (userRoleId === BaseTSConstants.SystemAdminRoleId) {
            return (
                <>
                    <Menu.Item key="Disciplines">Дисципліни</Menu.Item>
                    <Menu.Item key="2">Студенти</Menu.Item>
                    <Menu.Item key="3">Групи</Menu.Item>
                    <Menu.Item key="4">Завдання</Menu.Item>
                    <Menu.Item key="5">Оцінки</Menu.Item>
                    <Menu.Item key="6">Користувачі системи</Menu.Item>
                </>
            );
        }
    };

    const onUserLogout = () => {
        setUserId(null);
        setUserRoleId(null);
        navigate('/');
    };

    const menu = (
        <AntMenu>
            <AntMenu.Item onClick={onUserLogout}>Log out</AntMenu.Item>
        </AntMenu>
    );

    return (
        <Layout style={{ minHeight: '100vh', width:'100vw' }}>
            <Sider>
                <div className='menuHeading'>Меню</div>
                <Menu theme="dark" mode="inline" onClick={handleMenuClick}>
                    {renderMenuItems()}
                </Menu>
            </Sider>
            <Layout>
                <div id={"currentTabHeading"}>
                    <div className={'currentUserBlock'}>Привіт, {userName}!
                        <img src={userAvatar}/>
                        <Dropdown overlay={menu} placement="bottomRight">
                            <a className="ant-dropdown-link" onClick={(e) => e.preventDefault()}>
                                <DownOutlined />
                            </a>
                        </Dropdown>
                    </div>
                </div>
                <Content>
                    {renderContent()}
                </Content>
            </Layout>
        </Layout>
    );
};

export default MainMenu;
