import React, { useEffect, useState } from 'react';
import { Button, Table } from 'antd';
import axios from 'axios';
import EditGroupModal from "./EditGroupModal";
import './../Disciplines/Disciplines.styles.css';
import Cookies from "js-cookie";

type Group = {
    id: number;
    groupName: string;
    year: number;
    cafedra: {
        cafedraId: number;
        cafedraName: string;
    };
};

const Groups: React.FC = () => {
    const [groups, setGroups] = useState<Group[]>([]);
    const [selectedRowKeys, setSelectedRowKeys] = useState<React.Key[]>([]);
    const [editingRecord, setEditingRecord] = useState<any | null>(null);
    const [editModalVisible, setEditModalVisible] = useState(false);
    const [addModalVisible, setAddModalVisible] = useState(false);

    const fetchGroups = async () => {
        const response = await axios.get('https://localhost:7264/api/Group/GetGroupsInfo');
        setGroups(response.data.$values as Group[]);
    };

    useEffect(() => {
        Cookies.set("lastTab", "Groups");
        fetchGroups();
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
            const record = groups.find(s => s.id === parseInt(selectedRowKeys[0].toString()));
            setEditingRecord(record);
            setEditModalVisible(true);
        }
    };

    const onDeleteButtonClick = async () => {
        if (selectedRowKeys.length === 1) {
            await axios.post(`https://localhost:7264/api/Group/DeleteGroup?id=${parseInt(selectedRowKeys[0].toString())}`);
            fetchGroups();
        }
    };

    const rowSelection = {
        selectedRowKeys,
        onChange: onSelectChange,
    };

    const columns = [
        { title: 'Назва групи', dataIndex: 'groupName', key: 'groupName' },
        { title: 'Рік вступу', dataIndex: 'year', key: 'year' },
        { title: 'Кафедра', dataIndex: ['cafedra', 'cafedraName'], key: 'cafedra' },
    ];

    return (
        <div>
            <div className="disciplineHeading">
                <h2>Групи</h2>
                <div className="crudButtonsContainer">
                    <Button style={{ marginRight: '10px' }} type="primary" onClick={onAddButtonClick}>Додати</Button>
                    <Button style={{ marginRight: '10px' }} type="primary" onClick={onEditButtonClick}>Редагувати</Button>
                    <Button type="primary" danger onClick={onDeleteButtonClick}>Видалити</Button>
                </div>
            </div>
            <Table dataSource={groups} columns={columns} rowKey="id" rowSelection={rowSelection} />
            <EditGroupModal
                visible={addModalVisible}
                onSave={() => {
                    setAddModalVisible(false);
                    fetchGroups();
                }}
                onCancel={() => setAddModalVisible(false)}
                isEditMode={false}
                record={undefined}
                fetchGroups={fetchGroups}
            />
            <EditGroupModal
                record={editingRecord}
                visible={editModalVisible}
                onSave={() => {
                    setEditModalVisible(false);
                    fetchGroups();
                }}
                onCancel={() => setEditModalVisible(false)}
                isEditMode={true}
                fetchGroups={fetchGroups}
            />
        </div>
    );
};

export default Groups;
