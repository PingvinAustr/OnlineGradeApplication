import React, { useEffect, useState } from 'react';
import axios from 'axios';
import {Spin, Table} from 'antd';
import Cookies from 'js-cookie';
import './UserInfo.css';
import TeacherCard from "../TeacherCard";
// Define interfaces
interface UserData {
    firstName: string;
    secondName: string;
    lastName: string;
    age: number;
}

interface StudentCardData {
    enrollmentYear: string;
    birthDate: string;
    gender: string;
    studentStatusId: number;
    email: string;
    motherName: string;
    fatherName: string | null;
    phoneNumber: string | null;
    courseWorkTopicBachelor: string | null;
    courseWorkLeaderBachelor: number | null;
    courseWorkTopicMaster: string | null;
    courseWorkLeaderMaster: number | null;
    contractDate: string | null;
}

interface StudentStatusData {
    statusName: string;
}

interface PersonData {
    firstName: string;
    secondName: string;
    lastName: string;
    age: number;
}



const UserInfo = ({ userIdPassed, userRoleIdPassed }: { userIdPassed: number | null, userRoleIdPassed: number | null }) => {
    const [userData, setUserData] = useState<UserData | null>(null);
    if (userRoleIdPassed == null) userIdPassed = parseInt(Cookies.get("userRoleId") as string);

    useEffect(() => {
        const fetchUserData = async () => {
            try {
                let userHereId;
                if (userIdPassed == null)
                    userHereId = Cookies.get('userId');
                else userHereId = userIdPassed;

                const response = await axios.get(`https://localhost:7264/api/Person/${userHereId}`);

                setUserData(response.data);
            } catch (error) {
                console.error('Error fetching user data:', error);
            }
        };

        fetchUserData();
    }, []);

    if (!userData) {
        return <Spin />;
    }

    const { firstName, secondName, lastName, age } = userData;
    const avatarSrc = require(`../../assets/media/avatars/${Cookies.get('userId')}.png`);

    return (
        <div>
            <div style={{ width: '65%', height: '35%', display: 'flex', margin: '0 auto' }}>
                <div style={{ display: 'flex', alignItems: 'center', justifyContent: 'center' }}>
                    <img src={avatarSrc} style={{ width: '256px', height: '256px' }} alt="User Avatar" />
                </div>
                <div className="nameClass" style={{ fontSize: '20px', marginLeft: '50px', display: 'flex', flexDirection: 'column', justifyContent: 'center' }}>
                    <h3>Ім'я: {firstName}</h3>
                    <h3>Прізвище: {lastName}</h3>
                    <h3>По батькові: {secondName}</h3>
                    <h3>Вік: {age}</h3>
                </div>
            </div>
            <div style={{ width: '65%', height: '65%', display: 'flex', margin: '0 auto' }}>
                {userRoleIdPassed == 1002 ? (
                    <TeacherCard userId={Cookies.get('userId')} />
                ) : (
                    <StudentCard userId={Cookies.get('userId')} />
                )}
            </div>
        </div>
    );
};

interface StudentCardProps {
    userId: string | undefined;
}

const StudentCard: React.FC<StudentCardProps> = ({ userId }) => {
    const [studentCardData, setStudentCardData] = useState<StudentCardData | null>(null);
    const [studentStatusData, setStudentStatusData] = useState<StudentStatusData | null>(null);
    const [courseWorkLeaderBachelorData, setCourseWorkLeaderBachelorData] = useState<PersonData | null>(null);
    const [courseWorkLeaderMasterData, setCourseWorkLeaderMasterData] = useState<PersonData | null>(null);

    useEffect(() => {
        const fetchStudentCardData = async () => {
            try {
                const response = await axios.get(`https://localhost:7264/api/StudentCard/GetStudentCardByStudentId?id=${userId}`);

                const [studentCard] = response.data.$values;
                setStudentCardData(studentCard);

                if (studentCard.studentStatusId) {
                    const studentStatusResponse = await axios.get(`https://localhost:7264/api/StudentStatus/${studentCard.studentStatusId}`);
                    setStudentStatusData(studentStatusResponse.data);
                }

                if (studentCard.courseWorkLeaderBachelor) {
                    const courseWorkLeaderBachelorResponse = await axios.get(`https://localhost:7264/api/Person/${studentCard.courseWorkLeaderBachelor}`);
                    setCourseWorkLeaderBachelorData(courseWorkLeaderBachelorResponse.data);
                }

                if (studentCard.courseWorkLeaderMaster) {
                    const courseWorkLeaderMasterResponse = await axios.get(`https://localhost:7264/api/Person/${studentCard.courseWorkLeaderMaster}`);
                    setCourseWorkLeaderMasterData(courseWorkLeaderMasterResponse.data);
                }
            } catch (error) {
                console.error('Error fetching student card data:', error);
            }
        };

        fetchStudentCardData();
    }, [userId]);

    if (!studentCardData || !studentStatusData || !courseWorkLeaderBachelorData || !courseWorkLeaderMasterData) {
        return <Spin />;
    }

    const {
        enrollmentYear,
        birthDate,
        gender,
        studentStatusId,
        email,
        motherName,
        fatherName,
        phoneNumber,
        courseWorkTopicBachelor,
        courseWorkLeaderBachelor,
        courseWorkTopicMaster,
        courseWorkLeaderMaster,
        contractDate,
    } = studentCardData;

    const dataSource = [
        {
            key: '1',
            label: 'Email:',
            value: email,
        },
        {
            key: '2',
            label: 'Мобільний телефон:',
            value: phoneNumber,
        },
        {
            key: '3',
            label: 'Стать:',
            value: gender,
        },
        {
            key: '4',
            label: 'Статус студента:',
            value: studentStatusData.statusName,
        },
        {
            key: '5',
            label: 'Рік вступу:',
            value: enrollmentYear,
        },
        {
            key: '6',
            label: "ПІБ матері:",
            value: motherName,
        },
        {
            key: '7',
            label: "ПІБ батька:",
            value: fatherName,
        },
        {
            key: '8',
            label: 'Дата народження:',
            value: birthDate,
        },
        {
            key: '9',
            label: 'Тема курсової (Бакалавр):',
            value: courseWorkTopicBachelor,
        },
        {
            key: '10',
            label: 'Куратор курсової (Бакалавр):',
            value: `${courseWorkLeaderBachelorData.firstName} ${courseWorkLeaderBachelorData.lastName}`,
        },
        {
            key: '11',
            label: 'Тема курсової (Магістр):',
            value: courseWorkTopicMaster,
        },
        {
            key: '12',
            label: 'Куратор курсової (Магістр):',
            value: `${courseWorkLeaderMasterData.firstName} ${courseWorkLeaderMasterData.lastName}`,
        },
        {
            key: '13',
            label: 'Дата підписання контракту:',
            value: contractDate,
        },
    ];
    const columns = [
        {
            title: 'Колонка',
            dataIndex: 'label',
            key: 'label',
        },
        {
            title: 'Значення',
            dataIndex: 'value',
            key: 'value',
        },
    ];

    return (
        <div style={{width:"100%"}}>
            <h2>Картка студента</h2>
            <Table dataSource={dataSource} columns={columns} pagination={false} />
        </div>
    );
};

export default UserInfo;
