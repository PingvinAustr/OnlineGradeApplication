import React, { useEffect, useState } from 'react';
import { Table } from 'antd';
import axios from 'axios';
import Cookies from 'js-cookie';
import '../Disciplines/Disciplines.styles.css';

interface Teacher {
    id: number;
    firstName: string;
    lastName: string;
}

interface Student {
    id: number;
    firstName: string;
    secondName: string;
    lastName: string;
    age: number;
    roleId: number;
    systemAccessId: number;
}

interface Assignment {
    studentAssignmentId: number;
    student?: Student;
    createdByTeacher: Teacher;
    responsibleTeacher: Teacher;
    assignmentType: {
        id: number;
        assignmentName: string;
        assignmentWeightPercent?: number;
    };
    assignmentText?: string;
    createdOnDate: string;
    dueDate: string;
    studentGroup?: {
        groupId: number;
        groupName: string;
    };
}

const Assignments = () => {
    const tasksArray = ['Створити ПЗ "Калькулятор"', 'Написати твір про природу', 'Пострибати 20 разів', 'Створити SRS документ', 'Виконати практичну з ООП'];
    const [assignments, setAssignments] = useState<Assignment[]>([]);
    const userRoleId = Cookies.get('userRoleId');

    useEffect(() => {
        const fetchAssignments = async () => {
            try {
                if (userRoleId === '1003') {
                    const studentId = Cookies.get('userId');
                    const response = await axios.get(`https://localhost:7264/api/StudentAssignment/GetStudentAssignmentsByStudentId?studentId=${studentId}`);
                    setAssignments(response.data['$values']);
                } else if (userRoleId === '1002') {
                    const teacherId = Cookies.get('userId');
                    const response = await axios.get(`https://localhost:7264/api/StudentAssignment/GetTeacherAssignmentsByTeacherId?teacherId=${teacherId}`);
                    setAssignments(response.data['$values']);
                }
            } catch (error) {
                console.error('Error fetching assignments:', error);
            }
        };

        fetchAssignments();
    }, [userRoleId]);

    const studentColumns = [
        {
            title: 'Тип роботи',
            dataIndex: 'assignmentType',
            key: 'assignmentType',
            render: (assignmentType: any) => assignmentType.assignmentName,
        },
        {
            title: 'Завдання',
            dataIndex: 'assignmentText',
            key: 'assignmentText',
            render: () => {
                const randomIndex = Math.floor(Math.random() * tasksArray.length);
                return tasksArray[randomIndex];
            },
        },
        {
            title: 'Створено (викладач):',
            dataIndex: 'createdByTeacher',
            key: 'createdByTeacher',
            render: (createdByTeacher: Teacher) => `${createdByTeacher.firstName} ${createdByTeacher.lastName}`,
        },
        {
            title: 'Відповідальний (викладач)',
            dataIndex: 'responsibleTeacher',
            key: 'responsibleTeacher',
            render: (responsibleTeacher: Teacher) => `${responsibleTeacher.firstName} ${responsibleTeacher.lastName}`,
        },
        {
            title: 'Дата створення',
            dataIndex: 'createdOnDate',
            key: 'createdOnDate',
        },
        {
            title: 'Дедлайн',
            dataIndex: 'dueDate',
            key: 'dueDate',
        },
    ];

    const teacherColumns = [
        {
            title: 'Повне ім\'я студента',
            dataIndex: 'student',
            key: 'student',
            render: (student: Student) => `${student.firstName} ${student.secondName} ${student.lastName}`,
        },
        {
            title: 'Назва групи',
            dataIndex: 'studentGroup',
            key: 'studentGroup',
            render: (studentGroup: { groupName: string }) => studentGroup.groupName,
        },
        {
            title: 'Створено (викладач):',
            dataIndex: 'createdByTeacher',
            key: 'createdByTeacher',
            render: (createdByTeacher: Teacher) => `${createdByTeacher.firstName} ${createdByTeacher.lastName}`,
        },
        {
            title: 'Відповідальний (викладач)',
            dataIndex: 'responsibleTeacher',
            key: 'responsibleTeacher',
            render: (responsibleTeacher: Teacher) => `${responsibleTeacher.firstName} ${responsibleTeacher.lastName}`,
        },
        {
            title: 'Дата створення',
            dataIndex: 'createdOnDate',
            key: 'createdOnDate',
        },
        {
            title: 'Дедлайн',
            dataIndex: 'dueDate',
            key: 'dueDate',
        },
        {
            title: 'Тип роботи',
            dataIndex: 'assignmentType',
            key: 'assignmentType',
            render: (assignmentType: any) => assignmentType.assignmentName,
        },
        {
            title: 'Завдання',
            dataIndex: 'assignmentText',
            key: 'assignmentText',
            render: () => {
                const randomIndex = Math.floor(Math.random() * tasksArray.length);
                return tasksArray[randomIndex];
            },
        },
    ];

    const columns = userRoleId === '1003' ? studentColumns : teacherColumns;

    return (
        <div>
            <div className="disciplineHeading">
                <h2>Завдання</h2>
            </div>
            <Table
                dataSource={assignments}
                columns={columns}
                rowKey={(record) => record.studentAssignmentId.toString()}
            />
        </div>
    );
};

export default Assignments;
