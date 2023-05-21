import React, { useEffect, useState } from 'react';
import {Button, Table} from 'antd';
import axios from 'axios';
import {useAuth} from "../../Auth/AuthContext";
import Cookies from "js-cookie";

type Student = {
    id: number;
    firstName: string;
    lastName: string;
    age:number;
    group:{
        groupName:string;
    }
    role: {
        roleName: string;
    };
};

const GroupList: React.FC = () => {
    const { userId } = useAuth();
    const [students, setStudents] = useState<Student[]>([]);
    const [groupName, setGroupName] = useState<string>('');

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

    const columns = [
        { title: 'Ім\'я', dataIndex: 'firstName', key: 'firstName' },
        { title: 'Прізвище', dataIndex: 'lastName', key: 'lastName' },
        { title: 'Вік', dataIndex: 'age', key: 'age' },
    ];

    return (
        <React.Fragment>
            <div className="disciplineHeading">
                <h2>Список групи {groupName}</h2>
            </div>
            <Table dataSource={students} columns={columns} rowKey="id"/>
        </React.Fragment>

    );
};

export default GroupList;
