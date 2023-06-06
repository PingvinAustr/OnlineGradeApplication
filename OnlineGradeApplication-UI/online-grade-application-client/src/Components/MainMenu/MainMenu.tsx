import React, {useEffect, useState} from 'react';
import './MainMenu.styles.css';
import {useAuth} from "../../Auth/AuthContext";
import {deleteGroupTeacherDisciplineEntry, getUserDataById, setCurrentUser} from "../../Requests/Requests";
import { Layout, Menu } from 'antd';
import {BaseTSConstants} from "../../assets/constants/BaseTSConstants";
import { Dropdown, Menu as AntMenu } from 'antd';
import { DownOutlined } from '@ant-design/icons';
import { useNavigate } from 'react-router-dom';
import Disciplines from '../Disciplines/Disciplines';
import Students from "../Students/Students";
import Groups from "../Groups/Groups";
import SystemAccesses from "../SystemAccesses/SystemAccesses";
import GroupList from "../GroupList/GroupList";
import Cookies from "js-cookie";
import UserInfo from "../UserInfo/UserInfo";
import StudentTeachers from "../Teachers/StudentTeachers";
import Assignments from "../Assignments/Assignments";
import Marks from '../Marks/Marks';
const { Sider, Content } = Layout;



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
             case 'Students':
                 return <Students />;
            case 'Groups':
                return <Groups/>
            case 'SystemAccesses':
                return  <SystemAccesses/>
            case 'GroupList':
                return <GroupList/>
            case 'StudentTeachers':
                return <StudentTeachers/>
            case 'Assignments':
                return <Assignments/>
            case 'Marks':
                return <Marks/>
            default:
                return <UserInfo userIdPassed={parseInt(Cookies.get("userId") as string)} userRoleIdPassed={parseInt(Cookies.get("userRoleId") as string)}/>;
        }
    };

    useEffect(() => {
        const isUserLoggedIn = Cookies.get('isUserLoggedIn');
        if (isUserLoggedIn=='false' || !Cookies.get('isUserLoggedIn')) navigate('/');
        else {
            let lastTab:string = Cookies.get('lastTab') as string;
            setSelectedMenuItem(lastTab);
            setCurrentUser(parseInt(Cookies.get('userId') as string));
        }
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
                    <Menu.Item key="Marks">Оцінки</Menu.Item>
                    <Menu.Item key="Assignments">Завдання</Menu.Item>
                    <Menu.Item key="Disciplines">Дисципліни</Menu.Item>
                    <Menu.Item key="StudentTeachers">Викладачі</Menu.Item>
                    <Menu.Item key="GroupList">Список групи</Menu.Item>
                    <Menu.Item key="x">Мій профіль</Menu.Item>
                </>
            );
        } else if (userRoleId === BaseTSConstants.TeacherRoleId) {
            return (
                <>
                    <Menu.Item key="Disciplines">Дисципліни</Menu.Item>
                    <Menu.Item key="Students">Студенти</Menu.Item>
                    <Menu.Item key="Groups">Групи</Menu.Item>
                    <Menu.Item key="Assignments">Завдання</Menu.Item>
                    <Menu.Item key="Marks">Оцінки</Menu.Item>
                    <Menu.Item key="x">Мій профіль</Menu.Item>
                </>
            );
        }
        else if (userRoleId === BaseTSConstants.AdministrationPersonRoleId) {
            return (
                <>
                    <Menu.Item key="Disciplines">Дисципліни</Menu.Item>
                    <Menu.Item key="Students">Студенти</Menu.Item>
                    <Menu.Item key="Groups">Групи</Menu.Item>
                    <Menu.Item key="SystemAccesses">Користувачі системи</Menu.Item>
                    <Menu.Item key="x">Мій профіль</Menu.Item>
                </>
            );
        }
        else if (userRoleId === BaseTSConstants.SystemAdminRoleId) {
            return (
                <>
                    <Menu.Item key="Disciplines">Дисципліни</Menu.Item>
                    <Menu.Item key="Students">Студенти</Menu.Item>
                    <Menu.Item key="Groups">Групи</Menu.Item>
                    <Menu.Item key="SystemAccesses">Користувачі системи</Menu.Item>
                    <Menu.Item key="x">Мій профіль</Menu.Item>
                </>
            );
        }
    };

    const onUserLogout = () => {
        setUserId(null);
        setUserRoleId(null);
        Cookies.set("isUserLoggedIn", "false");
        Cookies.set("userId", "");
        Cookies.set("userRoleId", "");
        Cookies.set("lastTab", "");
        navigate('/');
    };

    const menu = (
        <AntMenu>
            <AntMenu.Item onClick={onUserLogout}>Вийти</AntMenu.Item>
        </AntMenu>
    );

    const [showUserInfo, setShowUserInfo] = useState(false);

    const handleUserInfoClick = () => {
        Cookies.set('lastTab', "");
        let lastTab:string = Cookies.get('lastTab') as string;
        setSelectedMenuItem(lastTab);
    };

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
                        <img style={{cursor:"pointer"}} onClick={handleUserInfoClick} src={require("../../assets/media/avatars/"  + Cookies.get("userId") + ".png")}/>
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
