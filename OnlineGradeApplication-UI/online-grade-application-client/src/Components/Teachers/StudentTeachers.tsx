import React, { useEffect, useState } from 'react';
import { Table } from 'antd';
import axios from 'axios';
import Cookies from 'js-cookie';
import '../Disciplines/Disciplines.styles.css';

type Teacher = {
    id: number;
    firstName: string;
    secondName: string;
    lastName: string;
    age: number;
};

type Discipline = {
    id: number;
    disciplineName: string;
};

type TeacherDiscipline = {
    teacherId: number;
    teacher: Teacher;
    discipline: Discipline;
};

const StudentTeachers: React.FC = () => {
    const [teacherData, setTeacherData] = useState<TeacherDiscipline[]>([]);

    const fetchTeachers = async () => {
        try {
            const personId = Cookies.get('userId');
            const response = await axios.get(`https://localhost:7264/api/Person/GetTeachersByGroupId?personId=${personId}`);
            setTeacherData(response.data.$values);
        } catch (error) {
            console.error('Error fetching teacher data:', error);
        }
    };

    useEffect(() => {
        fetchTeachers();
    }, []);

    const columns = [
        { title: 'Викладач', dataIndex: 'teacher', render: (teacher: Teacher) => `${teacher.firstName} ${teacher.lastName}` },
        { title: 'Предмет', dataIndex: 'discipline', render: (discipline: Discipline) => discipline.disciplineName },
    ];

    return (
        <div>
        <div className="disciplineHeading">
            <h2>Викладачі Вашої групи</h2>
        </div>
        <Table dataSource={teacherData} columns={columns} rowKey="teacherId" />
        </div>
    );
};

export default StudentTeachers;
