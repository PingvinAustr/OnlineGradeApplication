import React, { useEffect, useState } from 'react';
import { Button, Table } from 'antd';
import axios from 'axios';
import { useAuth } from "../../Auth/AuthContext";
import Cookies from "js-cookie";
import { useNavigate } from 'react-router-dom';
import UserInfo from "../UserInfo/UserInfo";

type Student = {
    id: number;
    firstName: string;
    lastName: string;
    age: number;
    group: {
        groupName: string;
    };
    role: {
        roleName: string;
    };
};

const GroupList: React.FC = () => {
    const { userId } = useAuth();
    const [students, setStudents] = useState<Student[]>([]);
    const [groupName, setGroupName] = useState<string>('');
    const navigate = useNavigate();
    const [selectedStudentId, setSelectedStudentId] = useState<number | null>(null);

    const fetchStudents = async () => {
        Cookies.set("lastTab", "GroupList");
        try {
            const groupIdResponse = await axios.get(`https://localhost:7264/api/Group/GetGroupIdByStudentId?studentId=${userId}`);
            const groupId = groupIdResponse.data;
            const studentsResponse = await axios.get(`https://localhost:7264/api/Person/GetStudentByGroupId?groupId=${groupId}`);
            setStudents(studentsResponse.data.$values as Student[]);
            console.log(studentsResponse.data.$values as Student[])
            setGroupName(studentsResponse.data.$values[0].group.groupName);
        } catch (err) {
            console.error(err);
        }
    };

    useEffect(() => {
        fetchStudents();
    }, []);

    const handleStudentClick = (userId: number) => {
        // Handle the click event here, e.g., open UserInfo for the selected student
        console.log("Clicked student ID:", userId);
        setSelectedStudentId(userId);
        // Perform any desired action using the clicked student's ID
    };

    const columns = [
        { title: 'Ім\'я', dataIndex: 'firstName', key: 'firstName', render: (text: string, record: Student) => <Button onClick={() => handleStudentClick(record.id)} type="link">{text}</Button> },
        { title: 'Прізвище', dataIndex: 'lastName', key: 'lastName' },
        { title: 'Вік', dataIndex: 'age', key: 'age' },
    ];

    return (
        <React.Fragment>
            <div className="disciplineHeading">
                <h2>Список групи {groupName}</h2>
            </div>
            <Table dataSource={students} columns={columns} rowKey="id" />
        </React.Fragment>
    );
};

export default GroupList;
