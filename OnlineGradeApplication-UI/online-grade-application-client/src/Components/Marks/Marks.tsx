import React, { useEffect, useState } from 'react';
import { Table, Button, Modal, Form, Input, Select } from 'antd';
import axios from 'axios';
import Cookies from 'js-cookie';
import '../Disciplines/Disciplines.styles.css';

interface Student {
    id: number;
    firstName: string;
    lastName: string;
}

interface Teacher {
    id: number;
    firstName: string;
    lastName: string;
}

interface Mark {
    studentMarkId: number;
    student?: Student;
    teacher?: Teacher;
    assignmentType: string;
    assignmentId: number;
    mark: number;
    coefficient: number;
}

const { Option } = Select;

const Marks = () => {
    const [marks, setMarks] = useState<Mark[]>([]);
    const [students, setStudents] = useState<Student[]>([]);
    const [modalVisible, setModalVisible] = useState(false);

    const [form] = Form.useForm();

    const userRoleId = Cookies.get('userRoleId');

    useEffect(() => {
        const fetchMarks = async () => {
            try {
                let url = '';
                if (userRoleId === '1002') {
                    const teacherId = Cookies.get('userId');
                    url = `https://localhost:7264/api/StudentMark/GetMarksByTeacherId?teacherId=${teacherId}`;
                } else if (userRoleId === '1003') {
                    const studentId = Cookies.get('userId');
                    url = `https://localhost:7264/api/StudentMark/GetMarksByStudentId?id=${studentId}`;
                }

                if (url) {
                    const response = await axios.get(url);
                    setMarks(response.data['$values']);
                }
            } catch (error) {
                console.error('Error fetching marks:', error);
            }
        };

        const fetchStudents = async () => {
            try {
                const response = await axios.get('https://localhost:7264/api/Person/GetStudents');
                setStudents(response.data['$values']);
            } catch (error) {
                console.error('Error fetching students:', error);
            }
        };

        fetchMarks();
        fetchStudents();
    }, [userRoleId]);

    const columns = userRoleId === '1002'
        ? [
            {
                title: 'Повне ім\'я студента',
                dataIndex: 'student',
                key: 'student',
                render: (student: Student) =>
                    student ? `${student.firstName} ${student.lastName}` : '',
            },
            { title: 'Тип роботи', dataIndex: 'assignmentType', key: 'assignmentType' },
            { title: 'ID завдання', dataIndex: 'assignmentId', key: 'assignmentId' },
            { title: 'Оцінка', dataIndex: 'mark', key: 'mark' },
            { title: 'Коефіцієнт', dataIndex: 'coefficient', key: 'coefficient' },
        ]
        : [
            {
                title: 'Повне ім\'я викладача',
                dataIndex: 'teacher',
                key: 'teacher',
                render: (teacher: Teacher) =>
                    teacher ? `${teacher.firstName} ${teacher.lastName}` : '',
            },
            { title: 'Тип роботи', dataIndex: 'assignmentType', key: 'assignmentType' },
            { title: 'ID завдання', dataIndex: 'assignmentId', key: 'assignmentId' },
            { title: 'Оцінка', dataIndex: 'mark', key: 'mark' },
            { title: 'Коефіцієнт', dataIndex: 'coefficient', key: 'coefficient' },
        ];


    const handleAddMark = () => {
        setModalVisible(true);
    };

    const handleModalCancel = () => {
        setModalVisible(false);
        form.resetFields();
    };

    const handleModalOk = () => {
        form.validateFields().then((values) => {
            console.log(values);
            const newMark: Mark = {
                studentMarkId: marks.length + 1, // Generate a unique ID for the new mark (replace with the appropriate logic)
                student: JSON.parse(values.student),
                assignmentType: values.assignmentType,
                assignmentId: values.assignmentId,
                mark: values.mark,
                coefficient: values.coefficient,
            };

            setMarks((prevMarks) => [...prevMarks, newMark]);

            form.resetFields();
            setModalVisible(false);
        });
    };

    return (
        <div>
            <div className="marksHeading" style={{display:"flex", flexDirection:"row", alignItems:"center", paddingLeft:"10px"}}>
                <h2>Оцінки</h2>
                {userRoleId === '1002' && (
                    <Button style={{marginLeft:"80%"}} type="primary" onClick={handleAddMark}>
                        Додати оцінку
                    </Button>
                )}
            </div>
            <Table dataSource={marks} columns={columns} rowKey={(record) => record.studentMarkId.toString()} />

            <Modal
                title="Додати оцінку"
                visible={modalVisible}
                onOk={handleModalOk}
                onCancel={handleModalCancel}
                okText="Зберегти"
                cancelText="Скасувати"
            >
                <Form form={form} layout="vertical">
                    <Form.Item
                        name="student"
                        label="Студент"
                        rules={[{ required: true, message: 'Будь ласка, оберіть студента' }]}
                    >
                        <Select placeholder="Оберіть студента">
                            {students.map((student) => (
                                <Option key={student.id} value={JSON.stringify(student)}>
                                    {`${student.firstName} ${student.lastName} (ID: ${student.id})`}
                                </Option>
                            ))}
                        </Select>
                    </Form.Item>

                    <Form.Item
                        name="assignmentType"
                        label="Тип роботи"
                        rules={[{ required: true, message: 'Будь ласка, оберіть тип роботи' }]}
                    >
                        <Select placeholder="Оберіть тип роботи">
                            <Option value="Курсова робота">Курсова робота</Option>
                            <Option value="дипломна робота">дипломна робота</Option>
                            <Option value="Лабораторна робота">Лабораторна робота</Option>
                            <Option value="практична робота">практична робота</Option>
                            <Option value="семінар">семінар</Option>
                        </Select>
                    </Form.Item>
                    <Form.Item
                        name="assignmentId"
                        label="ID завдання"
                        rules={[{ required: true, message: 'Будь ласка, введіть ID завдання' }]}
                    >
                        <Input />
                    </Form.Item>
                    <Form.Item
                        name="mark"
                        label="Оцінка"
                        rules={[{ required: true, message: 'Будь ласка, введіть оцінку' }]}
                    >
                        <Input type="number" />
                    </Form.Item>
                    <Form.Item
                        name="coefficient"
                        label="Коефіцієнт"
                        rules={[{ required: true, message: 'Будь ласка, введіть коефіцієнт' }]}
                    >
                        <Input type="number" />
                    </Form.Item>
                </Form>
            </Modal>
        </div>
    );
};

export default Marks;
