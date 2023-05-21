import React, { useEffect, useState } from 'react';
import { Button, Table } from 'antd';
import axios from 'axios';
import EditSystemAccessModal from "./EditSystemAccessModal";
import './../Disciplines/Disciplines.styles.css';
import Cookies from "js-cookie";

type SystemAccess = {
    $id: number;
    firstName: string;
    lastName: string;
    role: {
        roleName: string;
    };
    systemAccess: {
        id:number;
        username: string;
        userPassword: string;
    };
};

const SystemAccesses: React.FC = () => {
    const [systemAccesses, setSystemAccesses] = useState<SystemAccess[]>([]);
    const [selectedRowKeys, setSelectedRowKeys] = useState<React.Key[]>([]);
    const [editingRecord, setEditingRecord] = useState<any | null>(null);
    const [editModalVisible, setEditModalVisible] = useState(false);

    const fetchSystemAccesses = async () => {
        const response = await axios.get('https://localhost:7264/api/SystemAccess/GetSystemUserAccesses');
        console.log(response.data.$values as SystemAccess[]);
        setSystemAccesses(response.data.$values as SystemAccess[]);
    };

    const onSelectChange = (selectedKeys: React.Key[]) => {
        setSelectedRowKeys(selectedKeys);
    };

    useEffect(() => {
        Cookies.set("lastTab", "SystemAccesses");
        fetchSystemAccesses();
    }, []);

    const onAddButtonClick = () => {
        setEditingRecord(null);
        setEditModalVisible(true);
    };

    const onEditButtonClick = () => {
        console.log(selectedRowKeys);
        if (selectedRowKeys.length === 1) {
            const record = systemAccesses.find(sa => sa.systemAccess.id == parseInt(selectedRowKeys[0].toString()));
            setEditingRecord(record);
            setEditModalVisible(true);
        }
    };

    const onDeleteButtonClick = () => {
        if (selectedRowKeys.length === 1) {
            axios.post(`https://localhost:7264/api/SystemAccess/DeleteSystemUser?id=${parseInt(selectedRowKeys[0].toString())}`)
                .then(() => {
                    fetchSystemAccesses();
                });
        }
    };
    const rowSelection = {
        selectedRowKeys,
        onChange: onSelectChange,
    };

    const columns = [
        { title: 'Ім\'я', dataIndex: 'firstName', key: 'firstName' },
        { title: 'Прізвище', dataIndex: 'lastName', key: 'lastName' },
        { title: 'Роль', dataIndex: ['role', 'roleName'], key: 'role' },
        { title: 'Логін', dataIndex: ['systemAccess', 'username'], key: 'username' },
        { title: 'Пароль', dataIndex: ['systemAccess', 'userPassword'], key: 'userPassword' },
    ];

    return (
        <div>
            <div className="disciplineHeading">
                <h2>Користувачі системи</h2>
                <div className="crudButtonsContainer">
            <Button type="primary" style={{ marginRight: '10px' }} onClick={onAddButtonClick}>Add System Access</Button>
            <Button type="primary" style={{ marginRight: '10px' }} onClick={onEditButtonClick}>Edit System Access</Button>
            <Button type="primary" danger onClick={onDeleteButtonClick}>Delete System Access</Button>
                </div>
            </div>
            <Table dataSource={systemAccesses} columns={columns}  rowKey={record => record.systemAccess.id}  rowSelection={rowSelection}/>
            <EditSystemAccessModal
                record={editingRecord}
                visible={editModalVisible}
                onSave={() => {
                    setEditModalVisible(false);
                    fetchSystemAccesses();
                }}
                onCancel={() => setEditModalVisible(false)}
                isEditMode={!!editingRecord}
            />
        </div>
    );
};

export default SystemAccesses;
