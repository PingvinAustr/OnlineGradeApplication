import React, { useEffect, useState } from 'react';
import { Button, Table } from 'antd';
import axios from 'axios';
import EditStudentModal from "./EditStudentModal";
import './../Disciplines/Disciplines.styles.css';
import Cookies from "js-cookie";
type Student = {
    id: number;
    firstName: string;
    lastName: string;
    age: number;
    group: {
        groupId: number;
        groupName: string;
        groupCafedraId: number;
        groupYear: number;
    };
};

const Students: React.FC = () => {
    const [students, setStudents] = useState<Student[]>([]);
    const [selectedRowKeys, setSelectedRowKeys] = useState<React.Key[]>([]);
    const [editingRecord, setEditingRecord] = useState<any | null>(null);
    const [editModalVisible, setEditModalVisible] = useState(false);
    const [addModalVisible, setAddModalVisible] = useState(false);

    const fetchStudents = async () => {
        const response = await axios.get('https://localhost:7264/api/Person/GetStudents');
        setStudents(response.data.$values as Student[]);
    };

    useEffect(() => {
        Cookies.set("lastTab", "Students");
        fetchStudents();
    }, []);

    const onSelectChange = (selectedKeys: React.Key[]) => {
        setSelectedRowKeys(selectedKeys);
    };

    const onAddButtonClick = () => {
        setEditingRecord(null);
        setAddModalVisible(true);
    };

    const onEditButtonClick = () => {
        if (selectedRowKeys.length === 1) {
            const record = students.find(s => s.id === parseInt(selectedRowKeys[0].toString()));
            setEditingRecord(record);
            setEditModalVisible(true);
        }
    };

    const rowSelection = {
        selectedRowKeys,
        onChange: onSelectChange,
    };

    const columns = [
        { title: 'First Name', dataIndex: 'firstName', key: 'firstName' },
        { title: 'Last Name', dataIndex: 'lastName', key: 'lastName' },
        { title: 'Age', dataIndex: 'age', key: 'age' },
        { title: 'Group', dataIndex: ['group', 'groupName'], key: 'group' },
    ];

    return (
        <div>

            <div className="disciplineHeading">
                <h2>Студенти</h2>
                <div className="crudButtonsContainer">
                <Button type="primary"  style={{ marginRight: '10px' }} onClick={onAddButtonClick}>Add Student</Button>
                <Button type="primary" style={{ marginRight: '10px' }} onClick={onEditButtonClick}>Edit Student</Button>
                </div>
            </div>
            <Table dataSource={students} columns={columns} rowKey="id" rowSelection={rowSelection} />
            <EditStudentModal
                visible={addModalVisible}
                onSave={() => {
                    setAddModalVisible(false);
                    fetchStudents();
                }}
                onUpdate={() => {
                    setAddModalVisible(false);
                    fetchStudents();
                }}
                onCancel={() => setAddModalVisible(false)}
                isEditMode={false}
                record={undefined}
            />
            <EditStudentModal
                record={editingRecord}
                visible={editModalVisible}
                onSave={() => {
                    setEditModalVisible(false);
                    fetchStudents();
                }}
                onUpdate={() => {
                    setEditModalVisible(false);
                    fetchStudents();
                }}
                onCancel={() => setEditModalVisible(false)}
                isEditMode={true}
            />
        </div>
    );
};

export default Students;
