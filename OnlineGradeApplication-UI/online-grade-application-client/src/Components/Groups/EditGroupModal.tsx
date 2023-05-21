import React, { useEffect, useState } from 'react';
import { Button, Form, Input, Modal, Select } from 'antd';
import axios from 'axios';

type Group = {
    id: number;
    groupName: string;
    year: number;
    cafedra: {
        cafedraId: number;
        cafedraName: string;
    };
};

type Cafedra = {
    cafedraId: number;
    cafedraName: string;
};

type EditGroupModalProps = {
    visible: boolean;
    onSave: () => void;
    onCancel: () => void;
    isEditMode: boolean;
    record?: Group | null;
    fetchGroups: () => void;
};

const EditGroupModal: React.FC<EditGroupModalProps> = ({ visible, onSave, onCancel, isEditMode, record, fetchGroups }) => {
    const [form] = Form.useForm();
    const [cafedras, setCafedras] = useState<Cafedra[]>([]);

    useEffect(() => {
        fetchCafedras();
        form.setFieldsValue({
            groupName: isEditMode ? record?.groupName : '',
            groupYear: isEditMode ? record?.year : '',
            groupCafedraId: isEditMode ? record?.cafedra.cafedraId : '',
        });
    }, [form, isEditMode, record]);

    const fetchCafedras = async () => {
        const response = await axios.get('https://localhost:7264/api/Cafedra');
        setCafedras(response.data.$values as Cafedra[]);
    };

    const handleSave = () => {
        form.validateFields().then(values => {
            if (isEditMode) {
                axios.post(`https://localhost:7264/api/Group/EditGroup?id=${record?.id}&name=${values.groupName}&year=${values.groupYear}&cafedraId=${values.groupCafedraId}`)
                    .then(() => {
                        fetchGroups();
                        onSave();
                    });
            } else {
                axios.post('https://localhost:7264/api/Group/AddGroup', {
                    groupName: values.groupName,
                    groupCafedraId: values.groupCafedraId,
                    groupYear: values.groupYear
                }).then(() => {
                    fetchGroups();
                    onSave();
                });
            }
        });
    };

    return (
        <Modal visible={visible} onCancel={onCancel} footer={null}>
            <Form form={form} layout="vertical">
                <Form.Item label="Group Name" name="groupName" rules={[{ required: true, message: 'Please input the group name!' }]}>
                    <Input />
                </Form.Item>
                <Form.Item label="Year" name="groupYear" rules={[{ required: true, message: 'Please input the year!' }]}>
                    <Input type="number" />
                </Form.Item>
                <Form.Item label="Cafedra" name="groupCafedraId" rules={[{ required: true, message: 'Please select the cafedra!' }]}>
                    <Select>
                        {cafedras.map((cafedra) => (
                            <Select.Option key={cafedra.cafedraId} value={cafedra.cafedraId}>
                                {cafedra.cafedraName}
                            </Select.Option>
                        ))}
                    </Select>
                </Form.Item>
                <Form.Item>
                    <Button type="primary" onClick={handleSave}>Save</Button>
                </Form.Item>
            </Form>
        </Modal>

    );
};

export default EditGroupModal;

